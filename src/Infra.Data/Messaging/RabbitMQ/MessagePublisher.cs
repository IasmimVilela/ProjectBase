using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polly;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TaskB3.Domain.Interfaces.Messaging;
using TaskB3.Domain.Models;

namespace TaskB3.Infra.Data.Messaging.RabbitMQ
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly IConnectionFactory _rabbitMqconnectionFactory;

        public MessagePublisher(IConnectionFactory connectionFactory)
        {
            _rabbitMqconnectionFactory = connectionFactory;
            _connection = _rabbitMqconnectionFactory.CreateConnection();
        }

        public void Publish(IEnumerable<MessageEnvelop> messages, string exchange)
        {
            try 
            {
                var retryPolicy = Policy.Handle<Exception>().Retry(3, (exception, retryCount) =>{ });

                retryPolicy.Execute(() => { PublicToRabbitMq(messages, exchange); });
                 
            }
            catch (Exception ex)
            {
                throw new Exception("MessagePublisher erro:" + ex.Message);
            }
        }

        private void PublicToRabbitMq(IEnumerable<MessageEnvelop> messages, string exchange)
        {
            using (var channel = _connection.CreateModel())
            { 
                foreach (var message in messages) 
                {
                    var json = JsonConvert.SerializeObject(message.Content, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                    Console.WriteLine($"[MessagePublisher] Exchange: {exchange} RoutingKey: {message.RoutingKey}, Message: {json} ");
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: exchange,
                        routingKey: message.RoutingKey,
                        mandatory: false,
                        basicProperties: null,
                        body: body); 
                }
            }
        } 
    }
}
