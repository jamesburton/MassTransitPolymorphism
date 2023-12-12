namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;
using System.Collections.Generic;

public class IdAndLog : IHasId, IHasLog, IParameters
{
    public List<string> Log { get; set; } = [];
    public long Id { get; set; }
    public static IdNameAndLog operator +(IdAndLog x, string name) => new() { Id = x.Id, Name = name, Log = x.Log };
    public static IdLogAndValue operator +(IdAndLog x, decimal value) => new() { Id = x.Id, Log = x.Log, Value = value };
}