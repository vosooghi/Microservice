// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqSample.Core.Entities;
using RabbitMqSample.Toolkit;
using System.Data.Common;
using System.Text;

ConnectionFactory _connectionFactory;
IConnection _connection;
IModel _model;
string QueueName= "SampleQueue";

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
    //QueueName = _model.QueueDeclare().QueueName;
    _model.QueueDeclare(QueueName,true,false,false,null);

}

