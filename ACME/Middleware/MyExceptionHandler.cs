using ACME.Core.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace ACME.API.Middleware
{
    public class MyExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                context.Response.ContentType = "text/json";
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var result = new BaseResult()
                {
                    code = 400,
                    message = ex.Message,
                };

                var json = JsonSerializer.Serialize(result);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
