
namespace ContactManagement.API.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Routing;
    using Serilog;
    using System.Net;

    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public CustomExceptionFilterAttribute()
        {
        }

        //Handle all unhandled exeption
        public override void OnException(ExceptionContext context)
        {
            var controllerClassName = $"{context.HttpContext.GetRouteValue("controller")}Controller";
            var action = context.HttpContext.GetRouteValue("action");

            Log.Logger.Error($"{controllerClassName} - {action} - Unhandled exception: {context.Exception}");
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(context.Exception.Message);

            base.OnException(context);
        }
    }
}
