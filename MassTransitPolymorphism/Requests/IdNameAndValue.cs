namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class IdNameAndValue : IHasId, IHasName, IResult
{
    public required string Name { get; set; }
    public decimal Value { get; set; }
    public long Id { get; set; }
}
