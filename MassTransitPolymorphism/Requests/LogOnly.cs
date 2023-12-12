using MassTransitPolymorphism.Interfaces;

namespace MassTransitPolymorphism.Requests;

public class LogOnly : IHasLog, IParameters
{
    public List<string> Log { get; set; } = [];
    public static NameAndLog operator +(LogOnly x, string name) => new() { Name = name, Log = x.Log };
    public static IdAndLog operator +(LogOnly x, long id) => new() { Id = id, Log = x.Log };
    public static LogAndValue operator +(LogOnly x, decimal value) => new() { Log = x.Log, Value = value };
}