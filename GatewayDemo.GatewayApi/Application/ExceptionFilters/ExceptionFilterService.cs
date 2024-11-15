using AspNetCore.ApiGateway.Application.ExceptionFilters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GatewayDemo.GatewayApi.Application.ExceptionFilters
{
    public class ExceptionFilterService : IGatewayExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context, string apiKey, string routeKey, string verb)
        {
            await Task.CompletedTask;
        }
    }

    public class PostExceptionFilterService : IPostGatewayExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context, string apiKey, string routeKey)
        {
            await Task.CompletedTask;
        }
    }
}
