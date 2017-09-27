using System;
using System.Net;
using System.Threading.Tasks;
using EpicShop.Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace EpicShop.API.Infrastructure.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
                await HandleExceptionAsync(context, exceptionType, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Type exceptionType, Exception exception)
        {
            var response = context.Response;

            if (exceptionType == typeof(EntityNotFoundExceptions))
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            await context.Response.WriteAsync(exception.ToString());
        }
    }
}
