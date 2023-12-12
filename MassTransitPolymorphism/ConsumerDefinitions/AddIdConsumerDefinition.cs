namespace MassTransitPolymorphism.ConsumerDefinitions;

using MassTransit;
using MassTransitPolymorphism.Consumers;

public class AddIdConsumerDefinition : ConsumerDefinition<AddIdConsumer>
{
    public AddIdConsumerDefinition() => EndpointName = "AddId";
}
