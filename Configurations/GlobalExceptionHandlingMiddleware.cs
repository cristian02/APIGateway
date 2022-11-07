using System.Net;
using System.Text.Json;
using GlobalErrorApi.Exceptions;

namespace GlobalErrorApi.Configurations; 
public class GlobalExceptionHandlignMiddleware
{
    private readonly RequestDelegate _next; 

    public GlobalExceptionHandlignMiddleware(RequestDelegate next) => _next = next; 

    public async Task Invoke(HttpContext context)
    {
        try{
            await _next(context);
        }catch(Exception ex){
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode status; 
        var stackTrace = ex.StackTrace; 
        string message = ""; 
        var exceptionType = ex.GetType(); 
        if (exceptionType == typeof(CustomerException)){
            message = ((CustomerException)ex).customerMessage;
            status =  ((CustomerException)ex).statusCode; 
            stackTrace =  ex.StackTrace; 
        }
        else{
             message = ex.Message; 
            status = HttpStatusCode.Unauthorized;
            stackTrace = ex.StackTrace; 
        }

        var exceptionResult = JsonSerializer.Serialize(new {error = message, stackTrace});
        context.Response.ContentType = "application/json"; 
        context.Response.StatusCode = (int) status;
        return context.Response.WriteAsync(exceptionResult);
    }
}