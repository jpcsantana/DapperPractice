using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace DapperPrac.Exception
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context){
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception ex)
        {
            context.Response.ContentType = "application/json";

            int statusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new {message = ex.Message});

            if(ex is NotFoundException) statusCode = (int)HttpStatusCode.NotFound;
            if(ex is BadRequestException) statusCode = (int)HttpStatusCode.BadRequest;

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}