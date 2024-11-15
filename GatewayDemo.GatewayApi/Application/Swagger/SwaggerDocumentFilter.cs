using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GatewayDemo.GatewayApi.Application.Swagger;

public class SwaggerDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var verbs = new[] { OperationType.Get, OperationType.Post };
        foreach (var path in swaggerDoc.Paths)
        {
            if (path.Key.StartsWith("/api/Gateway/{apiKey}") || path.Key.StartsWith("/api/Gateway/orchestration"))
            {
                var operationsToRemove = path.Value.Operations
                    .Where(o => !verbs.Contains(o.Key))
                    .Select(o => o.Key)
                    .ToList();
                
                foreach (var operation in operationsToRemove)
                {
                    path.Value.Operations.Remove(operation);
                }

                foreach (var operation in path.Value.Operations)
                {
                    var queryParam = operation.Value.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Query);
                    if (queryParam != null)
                    {
                        operation.Value.Parameters.Remove(queryParam);
                    }
                }
            }
            else
            {
                swaggerDoc.Paths.Remove(path.Key);
            }
        }
    }
}