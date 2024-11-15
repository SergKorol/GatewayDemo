using AspNetCore.ApiGateway;
using GatewayDemo.GatewayApi.Models;

namespace GatewayDemo.GatewayApi;

public static class OrchestrationService
{
    public static void Create(IApiOrchestrator orchestrator, IApplicationBuilder app)
        {
            orchestrator.AddApi("weatherservice", "https://localhost:5003/")
                                .AddRoute("forecast", GatewayVerb.GET, new RouteInfo { Path = "weatherforecast/forecast", ResponseType = typeof(IEnumerable<WeatherForecast>) })
                                .AddRoute("add", GatewayVerb.POST, new RouteInfo { Path = "weatherforecast/summaries/add", RequestType = typeof(WeatherSummaryRequest), ResponseType = typeof(string[]) });
        }
}