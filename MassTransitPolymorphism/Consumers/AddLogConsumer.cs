namespace MassTransitPolymorphism.Consumers;

using MassTransit;
using MassTransitPolymorphism.Interfaces;
using MassTransitPolymorphism.Requests;
using System.Threading.Tasks;

public class AddLogConsumer : BaseConsumer
{
    private static Random Random { get; } = new();

    public AddLogConsumer(IEndpointRouter router)
        : base(router)
    {
    }

    public override async Task Consume(ConsumeContext<IParameters> context)
    {
        List<string> log = ["Example log entries", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString()];

        IParameters parameters = context.Message switch
        {
            Empty empty => empty + log,
            NameOnly nameOnly => nameOnly + log,
            IdOnly idOnly => idOnly + log,
            IdAndName idAndName => idAndName + log,
            _ => throw new Exception($"Unsupported input model: {context.Message.GetType().Name}")
        };

        await SendNext(context, parameters);
    }
}
