using System;
using System.Collections.Generic;
using System.Text;

namespace TStack.RabbitMQ.Tool
{
    public class PublisherOption : BaseOption
    {
        public PublisherOption(string queue, bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            if (string.IsNullOrEmpty(queue))
                throw new ArgumentNullException(nameof(queue));
            QueueName = queue;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;
            Arguments = arguments;
            Exchange = "";
            RoutingKey = queue;
        }
        public PublisherOption(string exchange, string routingKey = "", bool durable = false, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            if (string.IsNullOrEmpty(exchange))
                throw new ArgumentNullException(nameof(exchange));
            Exchange = exchange;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;
            Arguments = arguments;
            QueueName = "";
        }
        internal string RoutingKey { get; set; }
        internal string Exchange { get; set; }
    }
}
