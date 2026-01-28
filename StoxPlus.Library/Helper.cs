using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace StoxPlus.Library
{
    public class Helper
    {
        public static Uri GetAbsoluteUri(IHttpContextAccessor httpContextAccessor)
        {
            HttpRequest request = httpContextAccessor.HttpContext.Request;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            if (request.Host.Port != null)
            {
                uriBuilder.Port = Convert.ToInt32(request.Host.Port);
            }
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Query = request.QueryString.ToString();
            return uriBuilder.Uri;
        }
    }
}
