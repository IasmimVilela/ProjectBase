using System; 
using TaskB3.Domain.Interfaces.Messaging;
using TaskB3.Domain.Models; 

namespace TaskB3.Infra.Data.Messaging.RabbitMQ
{
    public class SenderEmail : ISenderEmail
    {
        private readonly IMessagePublisher _messagePublisher;
        
        public SenderEmail(IMessagePublisher messagePublisher) 
        {
            _messagePublisher = messagePublisher;
        }
        public void Notify(string messageId, object content)
        {
            _messagePublisher.Publish(new[]
            {
                new MessageEnvelop
                {
                    RoutingKey = "RoutingKey",
                    Content = new
                    { 
                        Id = messageId,
                        EventName = "EventName",
                        Message = content,
                        PublishedAt = DateTime.UtcNow
                    }
                }
            }, "exchange");
        }
    }
}
