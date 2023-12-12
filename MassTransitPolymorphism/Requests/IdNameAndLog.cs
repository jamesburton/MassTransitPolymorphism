namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;
using System.Collections.Generic;

public class IdNameAndLog : IHasId, IHasName, IHasLog, IParameters
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public List<string> Log { get; set; } = [];
    public static IdNameLogAndValue operator +(IdNameAndLog x, decimal value) => new() { Id = x.Id, Name = x.Name, Log = x.Log, Value = value };
}
