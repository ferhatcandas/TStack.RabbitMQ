using System;
using System.Collections.Generic;
using System.Text;

namespace TStack.RabbitMQ.Tool
{
    public abstract class BaseOption
    {
        internal string QueueName { get; set; }
        internal bool Durable { get; set; }
        internal bool Exclusive { get; set; }
        internal bool AutoDelete { get; set; }
        internal IDictionary<string, object> Arguments { get; set; }
    }
}
