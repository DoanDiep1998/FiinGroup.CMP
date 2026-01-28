using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace StoxPlus.Library.ActionFilter
{
    public class APIValidationAttribute : Attribute,  IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object param;
            object param2;
          

            //Valid if PageIndex >0
            if (context.ActionArguments.TryGetValue("pageindex", out param))
            {
                if (Convert.ToInt32(param) <=0)
                {
                     throw new Exception("PageIndex value is invalid!", new ArgumentException("PageIndex could not be less than 0"));
                }
                
            }
            //Valid if PageSize <=500
            if (context.ActionArguments.TryGetValue("pagesize", out param))
            {
                if (Convert.ToInt32(param) > 500)
                {
                    throw new Exception("PageSize value is invalid!", new ArgumentException("PageSize could not be less than 0"));
                }

            }
            //Valid if date is correct and in range
            if (context.ActionArguments.TryGetValue("fromdate", out param) && context.ActionArguments.TryGetValue("todate", out param2))
            {
                try
                {
                    if ((Convert.ToDateTime(param2) - Convert.ToDateTime(param)).TotalDays > 31)
                    {

                        throw new Exception("Cannot request more than one month of data!", new ArgumentException(""));

                    }
                }
                catch (Exception)
                {
                    throw new Exception("Date value is invalid!", new ArgumentException(""));
                }

                //Check if DateType provided
                if (context.ActionArguments.TryGetValue("dateType", out param)==false)
                {
                    throw new Exception("DateType must be provided!", new ArgumentException(""));
                }
            }

            //Valid if period of time must within one day
            if (context.ActionArguments.TryGetValue("from", out param) && context.ActionArguments.TryGetValue("to", out param2))
            {
                try
                {
                    if ((Convert.ToDateTime(param2) - Convert.ToDateTime(param)).TotalHours > 24)
                    {

                        throw new Exception("Cannot request data of multiple days!", new ArgumentException(""));

                    }
                }
                catch (Exception)
                {
                    throw new Exception("Date time value is invalid!", new ArgumentException(""));
                }

                
            }

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

            await next();
        }
    }
}
