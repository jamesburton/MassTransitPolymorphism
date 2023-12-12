namespace MassTransitPolymorphism.Interfaces;

using MassTransitPolymorphism.Requests;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(IdAndValue), nameof(IdAndValue))]
[JsonDerivedType(typeof(IdLogAndValue), nameof(IdLogAndValue))]
[JsonDerivedType(typeof(IdNameAndValue), nameof(IdNameAndValue))]
[JsonDerivedType(typeof(IdNameLogAndValue), nameof(IdNameLogAndValue))]
[JsonDerivedType(typeof(LogAndValue), nameof(LogAndValue))]
[JsonDerivedType(typeof(NameAndValue), nameof(NameAndValue))]
[JsonDerivedType(typeof(NameLogAndValue), nameof(NameLogAndValue))]
[JsonDerivedType(typeof(ValueOnly), nameof(ValueOnly))]
public interface IResult : IHasValue
{
}