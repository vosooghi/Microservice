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


    var consumer = new EventingBasicConsumer(_model);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var payment = body.FromByteArray<Payment>();
        Console.WriteLine($" [x] Received {payment.FirstName} {payment.LastName} {payment.Value}");
    };
    _model.BasicConsume(queue: QueueName,
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();

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
    QueueName = _model.QueueDeclare().QueueName;
    _model.QueueBind(QueueName, ExchangeName, "");

}