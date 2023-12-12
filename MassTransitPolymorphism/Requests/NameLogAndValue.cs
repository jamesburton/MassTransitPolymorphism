namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class NameLogAndValue : IHasName, IHasLog, IResult
{
    public required string Name { get; set; }
    public List<string> Log { get; set; } = [];
    public decimal Value { get; set; }
}
