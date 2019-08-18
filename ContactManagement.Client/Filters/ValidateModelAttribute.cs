
namespace ContactManagement.MvcClient.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Serilog;
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException(nameof(actionContext));

            if (!actionContext.ModelState.IsValid)
            {
                Log.Error($"Model state is not valid- ErrorCount- {actionContext.ModelState.ErrorCount}");
            }
        }
    }
}
