namespace MassTransitPolymorphism.ConsumerDefinitions;

using MassTransit;
using MassTransitPolymorphism.Consumers;

public class AddNameConsumerDefinition : ConsumerDefinition<AddNameConsumer>
{
    public AddNameConsumerDefinition() => EndpointName = "AddName";
}
