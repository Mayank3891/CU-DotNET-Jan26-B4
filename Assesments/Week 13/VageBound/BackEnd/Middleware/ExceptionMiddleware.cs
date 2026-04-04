using BackEnd.Exceptions;

namespace BackEnd.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DestinationNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status404NotFound);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context, "An unexpected error occurred.", StatusCodes.Status500InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new { StatusCode = statusCode, Message = message };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}