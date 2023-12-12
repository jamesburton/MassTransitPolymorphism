namespace MassTransitPolymorphism.ConsumerDefinitions;

using MassTransit;
using MassTransitPolymorphism.Consumers;

public class AddLogConsumerDefinition : ConsumerDefinition<AddLogConsumer>
{
    public AddLogConsumerDefinition() => EndpointName = "AddLog";
}
