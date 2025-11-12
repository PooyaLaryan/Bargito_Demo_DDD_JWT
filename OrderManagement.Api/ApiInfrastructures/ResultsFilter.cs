using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderManagement.Domain.Dtos;

namespace OrderManagement.Api.ApiInfrastructures
{
    public class ResultsFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is not null)
                {
                    var type = objectResult.Value.GetType();

                    if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(ServiceResults<>))
                    {
                        var finalType = typeof(ServiceResults<>).MakeGenericType(type);
                        var wrapped = Activator.CreateInstance(finalType);
                        finalType.GetProperty("Data")?.SetValue(wrapped, objectResult.Value);
                        objectResult.Value = wrapped;
                    }
                }
                else
                {
                    objectResult.Value = ServiceResults<object>.Fail("No data returned");
                }
            }
            else if (context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(ServiceResults<object>.Fail("No content"));
            }

            await next();
        }
    }
}
