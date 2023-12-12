namespace MassTransitPolymorphism.Consumers;

using MassTransit;
using MassTransitPolymorphism.Interfaces;
using MassTransitPolymorphism.Requests;
using System.Threading.Tasks;

public class CalculateValueConsumer : IConsumer<IParameters>
{
    public async Task Consume(ConsumeContext<IParameters> context)
    {
        var value = context.GetHashCode() / 1000m;
        IResult result = context.Message switch
        {
            IdOnly idOnly => idOnly + value,
            IdAndLog idAndLog => idAndLog + value,
            IdAndName idAndName => idAndName + value,
            IdNameAndLog idNameAndLog => idNameAndLog + value,
            NameAndLog nameAndLog => nameAndLog + value,
            NameOnly nameOnly => nameOnly + value,
            Empty empty => empty + value,
            _ => throw new InvalidOperationException($"Unhandled type: {context.Message.GetType().Name}"),
        };

        var sendEndpoint = await context.GetSendEndpoint(new Uri("queue:LogResult"));
        await sendEndpoint.Send(result);
    }
}
