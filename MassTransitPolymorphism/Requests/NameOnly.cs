namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class NameOnly : IHasName, IParameters
{
    public required string Name { get; set; }

    public static IdAndName operator +(NameOnly nameOnly, int id) => new() { Id = id, Name = nameOnly.Name };
    public static NameAndValue operator +(NameOnly nameOnly, decimal value) => new() { Name = nameOnly.Name, Value = value };
    public static NameAndLog operator +(NameOnly nameOnly, List<string> log) => new() { Name = nameOnly.Name, Log = log };
}
