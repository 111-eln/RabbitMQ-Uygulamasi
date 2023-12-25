using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory=new ConnectionFactory{
    HostName="localhost"
};
var connection=factory.CreateConnection();
using var channel=connection.CreateModel();

channel.QueueDeclare("student",exclusive:false,autoDelete:false);
var consumer=new EventingBasicConsumer(channel);
consumer.Received+=Receiver;
channel.BasicConsume(queue:"student",consumer:consumer);
Console.ReadLine();
void Receiver(object model, BasicDeliverEventArgs e)
{
    var body=e.Body.ToArray();
    var message=Encoding.UTF8.GetString(body);
    System.Console.WriteLine($"received:{message}");
}


