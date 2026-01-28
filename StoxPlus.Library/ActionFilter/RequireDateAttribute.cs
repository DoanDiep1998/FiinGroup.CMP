using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace  StoxPlus.Library.ActionFilter
{
    public class RequireDateAttribute : Attribute, IAsyncActionFilter
    {
       
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object param;
            object param2;
            //Valid if fromDate is not null
            if (context.ActionArguments.TryGetValue("fromDate", out param) == false)
            {
                throw new Exception("Request must contain a value of fromDate and toDate. Date range must be within 30 days!", new ArgumentException(""));
            }
            //Valid if fromDate is not null
            if ( context.ActionArguments.TryGetValue("toDate", out param2) == false)
            {
                throw new Exception("Request must contain a value of fromDate and toDate. Date range must be within 30 days!", new ArgumentException(""));
            }

            await next();
        }
    }
}
