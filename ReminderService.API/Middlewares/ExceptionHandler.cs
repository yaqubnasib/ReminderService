using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace ReminderService.API.Middlewares
{
    public static class ExceptionHandler
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (contextFeature != null)
                    {
                        var errorType = contextFeature.Error.GetType();
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        var response = new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error. {contextFeature.Error.Message}"
                        };

                        var jsonResponse = JsonSerializer.Serialize(response);
                        await context.Response.WriteAsync(jsonResponse);
                    }
                });
            });
        }
    }
}
