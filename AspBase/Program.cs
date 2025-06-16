using AspBase.Extensions;
using AspBase.Extensions.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

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



var app = builder.Build();

// Middlewares
app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
// app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.Run();