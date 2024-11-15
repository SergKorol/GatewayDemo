using AspNetCore.ApiGateway.Application.ActionFilters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GatewayDemo.GatewayApi.Application.ActionFilters
{
    public class ActionFilterService : IGatewayActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, string apiKey, string routeKey, string verb)
        {
            await Task.CompletedTask;
        }
    }

    public class PostActionFilterService : IPostGatewayActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, string apiKey, string routeKey)
        {
            await Task.CompletedTask;
        }
    }
}
