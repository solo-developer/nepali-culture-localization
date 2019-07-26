using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localization
{
    public class RequestHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.Headers.Remove("Accept-Language");
            context.Request.Headers.Add("Accept-Language", "ne-NP");
            await _next.Invoke(context);
        }
    }
}
