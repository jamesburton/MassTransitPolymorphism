namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class IdAndValue : IHasId, IResult
{
    public long Id { get; set; }
    public decimal Value { get; set; }
}
