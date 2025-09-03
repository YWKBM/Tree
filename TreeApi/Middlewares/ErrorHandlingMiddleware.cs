using System.Text.Json;
using TreeApi.Middlewares.DTO;

namespace TreeApi.Middlewares;

public class ErrorHandlingMiddleware
    (
        RequestDelegate next,
        TreeLogic.Services.ExceptionService exceptionService
    )
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await handleException(context, ex);
        }
    }

    private async Task handleException(HttpContext context, Exception ex)
    {
        var eventId = await exceptionService.AddToJournal(ex, context.Request.Query.ToString());
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var errorItem = new ErrorResponse()
        {
            Id = eventId.ToString(),
            Type = ex.GetType().Name,
            Data = new ErrorResponse.DataItem()
            {
                Message = ex.Message,
            }
        };
        
        var response = JsonSerializer.Serialize(errorItem);

        await context.Response.WriteAsync(response);
    }
}

public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}