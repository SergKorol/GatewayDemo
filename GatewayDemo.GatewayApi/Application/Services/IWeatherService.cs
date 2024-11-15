using AspNetCore.ApiGateway;

namespace GatewayDemo.GatewayApi.Application.Services;

public interface IWeatherService
{
    HttpClientConfig GetClientConfig();
    Task<object> GetForecast(ApiInfo apiInfo, HttpRequest request);
}