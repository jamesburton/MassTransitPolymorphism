namespace MassTransitPolymorphism.Services;

using MassTransitPolymorphism.Interfaces;

public class StaticEndpointRouter : IEndpointRouter
{
    private readonly List<string> endpoints;

    public StaticEndpointRouter(List<string> endpoints)
        => this.endpoints = endpoints;

    public string GetFirstEndpoint() => endpoints.First();

    public string? GetNextEndpoint(string endpoint)
    {
        var index = endpoints.IndexOf(endpoint);

        return index < 0
            ? throw new Exception($"Endpoint {endpoint} was not matched, so cannot return next endpoint.")
            : index == endpoints.Count - 1
                ? null
                : endpoints[index + 1];
    }
}