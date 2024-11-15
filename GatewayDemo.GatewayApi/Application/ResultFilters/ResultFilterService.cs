using AspNetCore.ApiGateway.Application.ResultFilters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GatewayDemo.GatewayApi.Application.ResultFilters
{
    public class ResultFilterService : IGatewayResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, string apiKey, string routeKey, string verb)
        {
            await Task.CompletedTask;
        }
    }

    public class PostResultFilterService : IPostGatewayResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, string apiKey, string routeKey)
        {
            await Task.CompletedTask;
        }
    }
}
