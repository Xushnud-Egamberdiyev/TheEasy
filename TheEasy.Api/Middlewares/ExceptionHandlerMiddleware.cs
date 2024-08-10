using TheEasy.Api.Models;
using TheEasy.Services.Exceptions;

namespace TheEasy.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.stutusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StutusCode = ex.stutusCode,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            this.logger.LogError($"{ex.Message}\n\n\n");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StutusCode = 500,
                Message = ex.Message
            });

        }
    }
}
