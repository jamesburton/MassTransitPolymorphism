using MassTransit;
using MassTransitPolymorphism.Interfaces;
using MassTransitPolymorphism.Requests;
using MassTransitPolymorphism.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEndpointRouter>(
    new StaticEndpointRouter([
        "AddId",
        "AddName",
        "CalculateValue"
    ]));

builder.Services.AddMassTransit(mt => {
    // mt.AddConsumers(typeof(Program).Assembly);
    var types = typeof(Program).Assembly.GetTypes().Where(t => t.IsPublic && !t.IsAbstract).ToList();
    var consumers = types.Where(t => t.IsAssignableTo(typeof(IConsumer))).ToList();
    var consumerDefinitions = types.Where(t => t.IsAssignableTo(typeof(ConsumerDefinition<>))).ToList();
    foreach (var consumer in types.Where(t => t.IsPublic && t.IsAssignableTo(typeof(IConsumer))))
    {
        var consumerDefinitionType = typeof(ConsumerDefinition<>).MakeGenericType(consumer);
        var definition = consumerDefinitions.FirstOrDefault(t => t.IsAssignableTo(consumerDefinitionType));
        _ = definition == null
            ? mt.AddConsumer(consumer)
            : mt.AddConsumer(consumer, definition);
    }

    mt.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet(
    "pipeline",
    async ([FromServices] IBus bus, [FromServices] IEndpointRouter router, CancellationToken cancellationToken) =>
    {
        var endpoint = await bus.GetSendEndpoint(new Uri($"queue:{router.GetFirstEndpoint()}"));
        await endpoint.Send(new Empty(), cancellationToken);

        return TypedResults.Ok();
    })
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
