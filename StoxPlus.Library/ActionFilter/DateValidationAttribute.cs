using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoxPlus.Library.ActionFilter
{
    public class DateValidationAttribute : Attribute, IAsyncActionFilter
    {
        int numberOfDay;
        public DateValidationAttribute()
        {
            //Default data for Date range is 30
            numberOfDay = 30;
        }

        public DateValidationAttribute(int numDay)
        {
            numberOfDay = numDay;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object param;
            object param2;

            //Check if DateType provided
            if (context.ActionArguments.TryGetValue("dateType", out param) == false)
            {
                throw new Exception("DateType must be provided!", new ArgumentException(""));
            }

            //Valid if fromDate is not null
            if (context.ActionArguments.TryGetValue("fromDate", out param) == false)
            {
                throw new Exception("Request must contain a value of fromDate and toDate. Date range must be within " + numberOfDay + " days!", new ArgumentException(""));
            }
            //Valid if fromDate is not null
            if (context.ActionArguments.TryGetValue("toDate", out param2) == false)
            {
                throw new Exception("Request must contain a value of fromDate and toDate. Date range must be within " + numberOfDay + " days!", new ArgumentException(""));
            }

            //Valid if date is correct and in range
            if (context.ActionArguments.TryGetValue("fromdate", out param) && context.ActionArguments.TryGetValue("todate", out param2))
            {
                try
                {
                    if ((Convert.ToDateTime(param2) - Convert.ToDateTime(param)).TotalDays > numberOfDay)
                    {

                        throw new Exception("Cannot request more than " + numberOfDay + "  of data!", new ArgumentException(""));

                    }
                }
                catch (Exception)
                {
                    throw new Exception("Date value is invalid. Date range must be within " + numberOfDay + " days!", new ArgumentException(""));
                }

               
            }

            await next();
        }
    }
}
