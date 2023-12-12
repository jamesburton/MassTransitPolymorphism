namespace MassTransitPolymorphism.Consumers;

using MassTransit;
using MassTransitPolymorphism.Interfaces;
using System.Text.Json;
using System.Threading.Tasks;

public class LogResultConsumer : IConsumer<IResult>
{
    public Task Consume(ConsumeContext<IResult> context)
    {
        var msg = context.Message;

        Console.WriteLine($"LogResultConsumer received result of type {msg.GetType()} with value {msg.Value}");

        if (msg is IHasId withId)
            Console.WriteLine($"  - Id: {withId.Id}");

        if (msg is IHasName withName)
            Console.WriteLine($"  - Name: {withName.Name}");

        if (msg is IHasLog withLog)
            Console.WriteLine($"  - Log: {JsonSerializer.Serialize(withLog.Log)}");

        return Task.CompletedTask;
    }
}