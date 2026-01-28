using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoxPlus.Library.ActionFilter
{
    public class CommonValidationAttribute : Attribute, IAsyncActionFilter
    {
        object param;
        object param2;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Valid if exchange is correct
            if (context.ActionArguments.TryGetValue("exchange", out param))
            {
                if (param.ToString().ToLower() != "hose")
                {
                    if (param.ToString().ToLower() != "hnx")
                    {
                        if (param.ToString().ToLower() != "upcom")
                        {
                            throw new Exception("Value of exchange is invalid. Please use hose, hnx, or upcom", new ArgumentException(""));
                        }
                    }
                }
            }

            //Valid if order mode is correct
            if (context.ActionArguments.TryGetValue("order", out param))
            {
                if (param.ToString().ToLower() != "asc")
                {
                    if (param.ToString().ToLower() != "desc")
                    {
                     
                            throw new Exception("Value of order is invalid. Please use asc, or desc", new ArgumentException(""));
                        
                    }
                }
            }

            await next();
        }
    }
}
