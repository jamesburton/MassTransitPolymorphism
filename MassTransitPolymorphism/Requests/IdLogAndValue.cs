namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;
using System.Collections.Generic;

public class IdLogAndValue : IHasId, IHasLog, IResult
{
    public decimal Value { get; set; }
    public List<string> Log { get; set; } = [];
    public long Id { get; set; }
}
