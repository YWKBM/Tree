using System.Text.Json;
using TreeApi.Middlewares.DTO;
using TreeLogic.Services;

namespace TreeApi.Middlewares;

public class ErrorHandlingMiddleware
    (
        RequestDelegate next,
        IServiceProvider serviceProvider
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
        using var scope = serviceProvider.CreateScope();
        
        var exceptionService = scope.ServiceProvider.GetRequiredService<ExceptionService>();
        var eventId = await exceptionService.AddToJournal(ex, context.Request.QueryString.Value);
        
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