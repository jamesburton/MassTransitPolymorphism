namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class NameAndValue : IHasName, IResult
{
    public required string Name { get; set; }
    public decimal Value { get; set; }
}
