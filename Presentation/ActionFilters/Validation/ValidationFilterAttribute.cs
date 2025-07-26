using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionFilters.Validation;

public class ValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];

        var param = context.ActionArguments.FirstOrDefault(p => p.Value != null && p.Value.GetType().Name.Contains("Dto")).Value;
        
        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"Object is null. Controller : {controller} \n Action : {action}");
            return;
        }

        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .SelectMany(kvp => kvp.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            context.Result = new BadRequestObjectResult(new
            {
                errors
            });
        }
    }
}