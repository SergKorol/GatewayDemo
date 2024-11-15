using AspNetCore.ApiGateway.Middleware;

namespace GatewayDemo.GatewayApi.Application.MiddlewareService
{
    public class GatewayMiddlewareService : IGatewayMiddleware
    {
        public async Task Invoke(HttpContext context, string apiKey, string routeKey)
        {
            await Task.CompletedTask;
        }
    }
}
