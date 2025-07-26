using AspBase.Extensions;
using AspBase.Extensions.Middleware;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
        
});

// Entity and Repository configuration
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.RegisterRepositories();
builder.Services.AddAutoMapper(typeof(Program).Assembly); // For DTO map with entity structures

// Services Configuration
builder.Services.ConfigureServices();
builder.Services.RegisterServices();


// Output
builder.Services.AddCustomMediaTypes();


// Swagger middleware
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Identity Configuration
builder.Services.ConfigureJwt(configuration: builder.Configuration);
builder.Services.ConfigureIdentity();


// Action Filters
builder.Services.ConfigureActionFilters();


// Cors Settings
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});



var app = builder.Build();

// Middlewares
app.ConfigureExceptionHandler();


// Cors Settings
app.UseCors("AllowReact");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
// app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.Run();