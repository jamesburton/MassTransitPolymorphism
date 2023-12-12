namespace MassTransitPolymorphism.ConsumerDefinitions;

using MassTransit;
using MassTransitPolymorphism.Consumers;

public class LogResultConsumerDefinition : ConsumerDefinition<LogResultConsumer>
{
    public LogResultConsumerDefinition() => EndpointName = "LogResult";
}
