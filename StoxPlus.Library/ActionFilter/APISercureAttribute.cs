using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace StoxPlus.Library.ActionFilter
{
    public class APISercureAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var authString = context.HttpContext.Request.Headers["Authorization"].First().Split(" ")[1];

            var jsonToken = new JwtSecurityTokenHandler().ReadToken(authString) as JwtSecurityToken;

            string[] allowedAPIs = jsonToken.Claims.First(c => c.Type == "allowed_api").Value.ToString().Split(",");

            //Enabled
            if (jsonToken.Claims.First(c => c.Type == "enabled").Value.ToString().ToLower() == "false")
            {
                throw new Exception("Service was disabled!", new UnauthorizedAccessException("Service was disabled or pending license activation!"));
            }

            //StartAt & EndAt
            if (DateTime.Now < DateTime.Parse(jsonToken.Claims.First(c => c.Type == "start_date").Value.ToString()) || DateTime.Now > DateTime.Parse(jsonToken.Claims.First(c => c.Type == "end_date").Value.ToString()))
            {
                throw new Exception("Service is expired!", new UnauthorizedAccessException("Service is expired!"));
            }

            if (!allowedAPIs.Contains(actionName))
            {
                throw new Exception("This method is not allowed to execute!", new UnauthorizedAccessException("This method is not allowed to execute!"));
            }

          
           



            await next();
        }
    }
}
