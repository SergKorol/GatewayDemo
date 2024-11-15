using System.Text.Json;
using AspNetCore.ApiGateway;
using GatewayDemo.GatewayApi.Models;

namespace GatewayDemo.GatewayApi.Application.Services;

public class WeatherService : IWeatherService
{
    public HttpClientConfig GetClientConfig()
    {
        return new HttpClientConfig
        {
            CustomizeDefaultHttpClient = (httpClient, request) => httpClient.DefaultRequestHeaders.Add("My header", "My header value"),
            HttpClient = () => new HttpClient()
        };
    }

    public async Task<object> GetForecast(ApiInfo apiInfo, HttpRequest request)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"{apiInfo.BaseUrl}weatherforecast/forecast");

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<WeatherForecast[]>(await response.Content.ReadAsStringAsync()) ?? [];
    }
}