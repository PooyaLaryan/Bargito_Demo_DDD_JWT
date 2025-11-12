using OrderManagement.Domain.Dtos;

namespace OrderManagement.Api.ApiInfrastructures
{
    public class ResultsExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ResultsExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var result = ServiceResults<object>.Fail(ex.Message);
                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
