﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

args = new string[] { "CustomerNameChanged", "CustomerCreated" };
string exchangeName = "CustomerManagement";
var factory = new ConnectionFactory() { HostName = "localhost", Port =Protocols.DefaultProtocol.DefaultPort, UserName = "guest", Password = "guest" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: exchangeName,
                            type: "direct");
    var queueName = channel.QueueDeclare().QueueName;

    foreach (var severity in args)
    {
        channel.QueueBind(queue: queueName,
                          exchange: exchangeName,
                          routingKey: severity);
    }

    Console.WriteLine(" [*] Waiting for messages.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var routingKey = ea.RoutingKey;
        Console.WriteLine(" [x] Received '{0}':'{1}'",
                          routingKey, message);
    };
    channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}