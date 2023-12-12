namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class IdOnly : IHasId, IParameters
{
    public long Id { get; set; }
    public static IdAndName operator +(IdOnly x, string name) => new() { Id = x.Id, Name = name };
    public static IdAndLog operator +(IdOnly x, List<string> log) => new() { Id = x.Id, Log = log };
    public static IdAndValue operator +(IdOnly x, decimal value) => new() { Id = x.Id, Value = value };
}
