namespace MassTransitPolymorphism.Consumers;

using MassTransit;
using MassTransitPolymorphism.Interfaces;
using System.Threading.Tasks;

public abstract class BaseConsumer : IConsumer<IParameters>
{
    protected readonly IEndpointRouter Router;

    protected BaseConsumer(IEndpointRouter router) => Router = router;

    public abstract Task Consume(ConsumeContext<IParameters> context);

    public async Task SendNext(ConsumeContext<IParameters> context, IParameters parameters)
    {
        var nextEndpoint = Router.GetNextEndpoint(GetType().Name.Replace("Consumer", ""));
        var sendEndpoint = await context.GetSendEndpoint(new Uri($"queue:{nextEndpoint}"));
        await sendEndpoint.Send(parameters);
    }
}