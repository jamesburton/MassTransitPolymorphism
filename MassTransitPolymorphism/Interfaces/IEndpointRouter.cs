namespace MassTransitPolymorphism.Interfaces;

public interface IEndpointRouter
{
    string GetFirstEndpoint();
    string? GetNextEndpoint(string endpoint);
}