namespace MassTransitPolymorphism.Interfaces;

using MassTransitPolymorphism.Requests;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Empty), nameof(Empty))]
[JsonDerivedType(typeof(IdAndLog), nameof(IdAndLog))]
[JsonDerivedType(typeof(IdAndName), nameof(IdAndName))]
[JsonDerivedType(typeof(IdNameAndLog), nameof(IdNameAndLog))]
[JsonDerivedType(typeof(IdOnly), nameof(IdOnly))]
[JsonDerivedType(typeof(LogOnly), nameof(LogOnly))]
[JsonDerivedType(typeof(NameAndLog), nameof(NameAndLog))]
[JsonDerivedType(typeof(NameOnly), nameof(NameOnly))]
public interface IParameters
{
}