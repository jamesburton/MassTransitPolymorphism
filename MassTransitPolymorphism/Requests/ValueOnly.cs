namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class ValueOnly : IResult
{
    public decimal Value { get; set; }
}