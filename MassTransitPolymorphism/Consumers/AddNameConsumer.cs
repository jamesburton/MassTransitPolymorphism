namespace MassTransitPolymorphism.Consumers;

using MassTransit;
using MassTransitPolymorphism.Interfaces;
using MassTransitPolymorphism.Requests;
using System.Threading.Tasks;

public class AddNameConsumer : BaseConsumer
{
    public AddNameConsumer(IEndpointRouter router)
        : base(router)
    {
    }

    public override async Task Consume(ConsumeContext<IParameters> context)
    {
        var name = $"User_{Guid.NewGuid()}";

        IParameters parameters = context.Message switch
        {
            Empty empty => empty + name,
            IdOnly idOnly => idOnly + name,
            LogOnly logOnly => logOnly + name,
            IdAndLog idAndLog => idAndLog + name,
            _ => throw new Exception($"Unsupported input model: {context.Message.GetType().Name}")
        };

        await SendNext(context, parameters);
    }
}
