using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ogrencisistem.RabbitMQ;
public class RabbitMQProducer:IRabbitMQProducer{
     public void SendMessage<T>(T message){
        var factory=new ConnectionFactory{
            HostName="localhost"
        };
        var connection=factory.CreateConnection();
        using var channel=connection.CreateModel();
        channel.QueueDeclare("student",exclusive:false,autoDelete:false);
        var json=JsonConvert.SerializeObject(message);
        var body=Encoding.UTF8.GetBytes(json);
        channel.BasicPublish(exchange:"",routingKey:"student",body:body);
     }
}