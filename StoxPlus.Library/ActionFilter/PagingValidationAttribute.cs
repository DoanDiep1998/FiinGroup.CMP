using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoxPlus.Library.ActionFilter
{
    public class PagingValidationAttribute: Attribute, IAsyncActionFilter
    {
        int maxPageSize;
        public PagingValidationAttribute()
        {
            maxPageSize = 200;
        }

        public PagingValidationAttribute(int maxSize)
        {
            maxPageSize = maxSize;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object param;
            object param2;

            //Valid if PageIndex >0
            if (context.ActionArguments.TryGetValue("pageindex", out param))
            {
                if (Convert.ToInt32(param) <= 0)
                {
                    throw new Exception("PageIndex value is invalid!", new ArgumentException("PageIndex could not be less than 0"));
                }

            }
            //Valid if PageSize <=500
            if (context.ActionArguments.TryGetValue("pagesize", out param))
            {
                if (Convert.ToInt32(param) > maxPageSize)
                {
                    throw new Exception("PageSize value is invalid!", new ArgumentException("The max allowed data for PageSize is " + maxPageSize));
                }

            }

            await next();
        }
    }
}
