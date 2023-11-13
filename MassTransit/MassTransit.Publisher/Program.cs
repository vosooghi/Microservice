using MassTransit;
using MassTransit.Contracts;

var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
{
    sbc.Host("rabbitmq://localhost");
    sbc.ReceiveEndpoint("test_queue",ep =>
    { });
    
});

await bus.StartAsync();
string result = "";
do
{
    Console.WriteLine("Write your message ");
    var message = new Message
    {
        Text = Console.ReadLine()
    };
    await bus.Publish(message);
    Console.WriteLine("Continue messaging? y / anything else: ");
    result = Console.ReadLine().ToLower();
} while (result=="y");


await bus.StopAsync();