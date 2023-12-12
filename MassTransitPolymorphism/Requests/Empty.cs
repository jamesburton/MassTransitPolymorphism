namespace MassTransitPolymorphism.Requests;

using MassTransitPolymorphism.Interfaces;

public class Empty : IParameters
{
    public static IdOnly operator +(Empty _, int id) => new() { Id = id };
    public static NameOnly operator +(Empty _, string name) => new() { Name = name };
    public static ValueOnly operator +(Empty _, decimal value) => new() { Value = value };
    public static LogOnly operator +(Empty _, List<string> log) => new() { Log = log };
}