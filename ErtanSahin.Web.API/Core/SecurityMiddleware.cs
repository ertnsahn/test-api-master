using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ErtanSahin.Web.API.Core
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiExceptionHandlerMiddleware> _logger;


        public SecurityMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlerMiddleware> logger, IConfiguration configuration)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/api")))
            {

                if (context.Request.Headers.Keys.Contains("api-key"))
                {
                    string apiKey = context.Request.Headers["api-key"];

                    var allowedApiKeys = _configuration.GetValue<string>("api-keys").Split(",");
                    if (allowedApiKeys.All(x => x != apiKey))
                    {
                        throw new SecurityException("api key access is not allowed{api-key}");
                    }
                }
                else
                {
                    throw new SecurityException("need api key in header{api-key}");
                }
            }

            await _next(context);
        }
    }
}