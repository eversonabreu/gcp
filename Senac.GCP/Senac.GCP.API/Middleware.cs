using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Senac.GCP.API
{
    public sealed class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exc)
            {
                if (exc.Message == "401")
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token inválido ou expirado");
                }
                else
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(exc.Message);
                }
            }
        }
    }
}