using AspNetCore.ApiGateway;
using AspNetCore.ApiGateway.Application.ActionFilters;
using AspNetCore.ApiGateway.Application.ExceptionFilters;
using AspNetCore.ApiGateway.Application.HubFilters;
using AspNetCore.ApiGateway.Application.ResultFilters;
using AspNetCore.ApiGateway.Authorization;
using AspNetCore.ApiGateway.Middleware;
using GatewayDemo.GatewayApi;
using GatewayDemo.GatewayApi.Application.ActionFilters;
using GatewayDemo.GatewayApi.Application.Authorization;
using GatewayDemo.GatewayApi.Application.ExceptionFilters;
using GatewayDemo.GatewayApi.Application.HubFilters;
using GatewayDemo.GatewayApi.Application.MiddlewareService;
using GatewayDemo.GatewayApi.Application.ResultFilters;
using GatewayDemo.GatewayApi.Application.Services;
using GatewayDemo.GatewayApi.Application.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IWeatherService, WeatherService>();

//Authorization
builder.Services.AddScoped<IGatewayAuthorization, AuthorizationService>();
builder.Services.AddScoped<IGetOrHeadGatewayAuthorization, GetAuthorizationService>();

//Action filters
builder.Services.AddScoped<IGatewayActionFilter, ActionFilterService>();
builder.Services.AddScoped<IPostGatewayActionFilter, PostActionFilterService>();

//Exception filters
builder.Services.AddScoped<IGatewayExceptionFilter, ExceptionFilterService>();
builder.Services.AddScoped<IPostGatewayExceptionFilter, PostExceptionFilterService>();

//Result filters
builder.Services.AddScoped<IGatewayResultFilter, ResultFilterService>();
builder.Services.AddScoped<IPostGatewayResultFilter, PostResultFilterService>();

//Hub filters
builder.Services.AddScoped<IGatewayHubFilter, GatewayHubFilterService>();

//Middleware service
builder.Services.AddTransient<IGatewayMiddleware, GatewayMiddlewareService>();

builder.Services.AddApiGateway(options =>
{
    options.UseResponseCaching = false;
    options.ResponseCacheSettings = new ApiGatewayResponseCacheSettings
    {
        Duration = 60,
        Location = ResponseCacheLocation.Any,
        VaryByQueryKeys = ["apiKey", "routeKey"]
    };
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api Gateway", Version = "v1" });
    c.DocumentFilter<SwaggerDocumentFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseApiGateway(orchestrator => OrchestrationService.Create(orchestrator, app));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();