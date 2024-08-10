using TheEasy.Api.Models;
using TheEasy.Services.Exceptions;

namespace TheEasy.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
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
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StutusCode = 500,
                Message = ex.Message
            });

        }
    }
}
