using AspNetCore.ApiGateway.Application.HubFilters;
using Microsoft.AspNetCore.SignalR;

namespace GatewayDemo.GatewayApi.Application.HubFilters
{
    public class GatewayHubFilterService : IGatewayHubFilter
    {
        public ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext)
        {
            return new ValueTask<object>();
        }

        public Task OnConnectedAsync(HubLifetimeContext context)
        {
            return Task.CompletedTask;
        }

        public Task OnDisconnectedAsync(HubLifetimeContext context, Exception exception)
        {
            return Task.CompletedTask;
        }
    }
}
