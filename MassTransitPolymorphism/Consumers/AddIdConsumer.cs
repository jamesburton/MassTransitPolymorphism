namespace MassTransitPolymorphism.Consumers;

using MassTransit;
using MassTransitPolymorphism.Interfaces;
using MassTransitPolymorphism.Requests;
using System.Threading.Tasks;

public class AddIdConsumer : BaseConsumer
{
    private static Random Random { get; } = new();

    public AddIdConsumer(IEndpointRouter router)
        : base(router)
    {
    }

    public override async Task Consume(ConsumeContext<IParameters> context)
    {
        var id = Random.Next();

        IParameters parameters = context.Message switch
        {
            Empty empty => empty + id,
            NameOnly nameOnly => nameOnly + id,
            NameAndLog nameAndLog => nameAndLog + id,
            _ => throw new Exception($"Unsupported input model: {context.Message.GetType().Name}")
        };

        await SendNext(context, parameters);
    }
}
