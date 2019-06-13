using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using TStack.RabbitMQ.Connection;
using TStack.RabbitMQ.Tool;

namespace TStack.RabbitMQ
{
    public class Publisher<TContext>
        where TContext : RabbitMQConnection, new()
    {
        private TContext _context;
        private PublisherOption _publisherOption;
        public Publisher(PublisherOption publisherOption)
        {
            _context = new TContext();
            _publisherOption = publisherOption;
        }

        public void Send<T>(T Model)
        {

            using (var connection = _context.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _publisherOption.QueueName,
                                     durable: _publisherOption.Durable,
                                     exclusive: _publisherOption.Exclusive,
                                     autoDelete: _publisherOption.AutoDelete,
                                     arguments: _publisherOption.Arguments);

                string message = JsonConvert.SerializeObject(Model);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: _publisherOption.Exchange,
                                     routingKey: _publisherOption.RoutingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
