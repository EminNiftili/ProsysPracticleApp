using Microsoft.AspNetCore.Http;
using ProsysTestApp.Core.Helpers;

namespace ProsysTestApp.ApiConfig.MiddleWares
{
    public class GlobalErrorHandlingMiddleware : BaseMiddleware
    {
        public GlobalErrorHandlingMiddleware(RequestDelegate next) : base(next)
        {
        }
        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                int statusCode = 400;
                do
                {
                    if (ex is Exception)
                    {
                        message = ex.Message;
                        statusCode = 500;
                        break;
                    }
                    else
                    {
                        message = "Something went wrong.";
                        statusCode = 500;
                    }
                    ex = ex.InnerException;
                } while (ex != null);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                context.Response.WriteAsync(JsonSerializerHelper.Serialize(new { Message = message, StatusCode = statusCode }));
            }
        }
    }
}
