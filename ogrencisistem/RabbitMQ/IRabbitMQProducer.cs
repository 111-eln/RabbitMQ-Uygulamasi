namespace ogrencisistem.RabbitMQ;
public interface IRabbitMQProducer{
    public void SendMessage<T>(T message);
}