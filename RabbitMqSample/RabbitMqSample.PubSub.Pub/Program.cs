using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqSample.Core.Entities;
using System.Data.Common;
using RabbitMqSample.Toolkit;

ConnectionFactory _connectionFactory;
IConnection _connection;
IModel _model;
string QueueName;
const string ExchangeName = "MyPaymentServiceExchange";

CreateConnection();
string key;
do
{

    SendPayments(10);
    Console.WriteLine("".PadLeft(100, '-'));
    Console.WriteLine();

    Console.WriteLine("do you want to send message:y/any thing else ");
    key = Console.ReadLine();
    Console.WriteLine();

} while (key.ToLower() == "y");

void CreateConnection()
{
    _connectionFactory = new ConnectionFactory
    {
        HostName = "localhost",
        UserName = "guest",
        Password = "guest",
        Port = Protocols.DefaultProtocol.DefaultPort
    };
    _connection = _connectionFactory.CreateConnection();
    _model = _connection.CreateModel();
    _model.ExchangeDeclare(ExchangeName,ExchangeType.Fanout ,false);
}

void SendPayments(int paymentCount)
{
    for (int i = 0; i < paymentCount; i++)
    {
        Payment payment = new Payment
        {
            FirstName = $"FiratName {i}",
            LastName = $"LastName {i}",
            CardNumber = $"1111-2222-3333-{i.ToString().PadLeft(4, '0')}",
            Value = Math.Pow(i / 3, 5)
        };
        _model.BasicPublish(ExchangeName, "", null, payment.ToByteArray());
        Console.WriteLine($"Message Send for {i}");
    }
}