using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoxPlus.Library.ActionFilter
{
    public class TrialServiceRestrictionAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object param;
            object param2;
            //Valid if fromDate is not null
            if (context.ActionArguments.TryGetValue("yearReport", out param) == false)
            {
                throw new Exception("Trial Service Restriction - Request must contain value of yearReport!", new ArgumentException("Trial Service Restriction"));
            }
            else
            {
              
                    if (DateTime.Now.Year - Convert.ToInt32(param) > 1)
                    {
                        throw new Exception("Trial Service Restriction- Not allow to access historical data!", new ArgumentException("Trial Service Restriction"));
                    }
              
            }
          

            await next();
        }
    }
}
