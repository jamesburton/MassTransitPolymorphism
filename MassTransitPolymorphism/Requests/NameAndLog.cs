namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;
using System.Collections.Generic;

public class NameAndLog : IHasName, IHasLog, IParameters
{
    public List<string> Log { get; set; } = [];
    public required string Name { get; set; }

    public static IdNameAndLog operator +(NameAndLog x, int id) => new() { Id = id, Name = x.Name, Log = x.Log };
    public static IdNameLogAndValue operator +(NameAndLog x, decimal value) => new() { Name = x.Name, Log = x.Log, Value = value };
}
