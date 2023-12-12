namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;
using System.Collections.Generic;

public class IdNameLogAndValue : IHasId, IHasName, IHasLog, IHasValue, IResult
{
    public long Id { get; set; }
    public decimal Value { get; set; }
    public required string Name { get; set; }
    public List<string> Log { get; set; } = [];
}
