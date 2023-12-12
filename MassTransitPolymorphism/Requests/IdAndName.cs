namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class IdAndName : IHasId, IHasName, IParameters
{
    public required string Name { get; set; }
    public long Id { get; set; }
    public static IdNameAndLog operator +(IdAndName x, List<string> log) => new() { Id = x.Id, Name = x.Name, Log = log };
    public static IdNameAndValue operator +(IdAndName x, decimal value) => new() { Id = x.Id, Name = x.Name, Value = value };
}
