using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using TStack.RabbitMQ.Connection;
using TStack.RabbitMQ.Tool;

namespace TStack.RabbitMQ
{
    public class Consumer<TContext>
           where TContext : RabbitMQConnection, new()
    {
        private ConsumerOption _consumerOption;
        private TContext _context;
        public Consumer(ConsumerOption consumerOption)
        {
            _consumerOption = consumerOption;
            _context = new TContext();
        }
        public void Recieve<T>(Func<T> func)
        {
            using (var connection = _context.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _consumerOption.QueueName,
                                     durable: _consumerOption.Durable,
                                     exclusive: _consumerOption.Exclusive,
                                     autoDelete: _consumerOption.AutoDelete,
                                     arguments: _consumerOption.Arguments);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    T data = JsonConvert.DeserializeObject<T>(message);
                    func();
                };
                channel.BasicConsume(queue: _consumerOption.QueueName,
                                     autoAck: _consumerOption.AutoAck,
                                     consumer: consumer);

            }
        }
    }
}
