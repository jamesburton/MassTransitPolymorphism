using MassTransitPolymorphism.Interfaces;
using IResult = MassTransitPolymorphism.Interfaces.IResult;

namespace MassTransitPolymorphism.Requests;

public class LogAndValue : IHasLog, IResult
{
    public List<string> Log { get; set; } = [];
    public decimal Value { get; set; }
}