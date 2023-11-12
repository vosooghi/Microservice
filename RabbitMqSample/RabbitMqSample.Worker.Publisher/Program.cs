// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMqSample.Core.Entities;
using RabbitMqSample.Toolkit;
using System.Text;

ConnectionFactory _connectionFactory;
IConnection _connection;
IModel _model;
const string QueueName = "SampleQueue";


CreateConnection();
string key;
do
{

    SendPayments(10);
    Console.WriteLine("".PadLeft(100, '-'));
    Console.WriteLine();

    Console.WriteLine("do you want to send message:y/anything else ");
    key = Console.ReadLine();
    Console.WriteLine();

} while (key.ToLower() == "y");

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
        _model.BasicPublish("", QueueName, null, payment.ToByteArray());
        Console.WriteLine($"Message Send for {i}");
    }
}

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
    _model.QueueDeclare(QueueName,true, false,false,null);
}



