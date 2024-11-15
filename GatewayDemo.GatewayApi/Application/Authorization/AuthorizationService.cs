using AspNetCore.ApiGateway.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GatewayDemo.GatewayApi.Application.Authorization
{
    public class AuthorizationService : IGatewayAuthorization
    {
        public async Task AuthorizeAsync(AuthorizationFilterContext context, string apiKey, string routeKey, string verb)
        {
            await Task.CompletedTask;
        }
    }

    public class GetAuthorizationService : IGetOrHeadGatewayAuthorization
    {
        public async Task AuthorizeAsync(AuthorizationFilterContext context, string apiKey, string routeKey)
        {
            await Task.CompletedTask;
        }
    }
}
