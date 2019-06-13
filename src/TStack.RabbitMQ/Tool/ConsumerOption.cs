using System;
using System.Collections.Generic;
using System.Text;

namespace TStack.RabbitMQ.Tool
{
    public class ConsumerOption : BaseOption
    {
        public ConsumerOption(string queue, bool durable = false, bool exclusive = false, bool autoDelete = false,bool autoAck=true, IDictionary<string, object> arguments = null)
        {
            if (string.IsNullOrEmpty(queue))
                throw new ArgumentNullException(nameof(queue));
            QueueName = queue;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;
            Arguments = arguments;
            AutoAck = autoAck;
        }
        internal bool AutoAck { get; set; }
    }
}
