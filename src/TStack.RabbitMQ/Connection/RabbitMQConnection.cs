using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace TStack.RabbitMQ.Connection
{
    public class RabbitMQConnection : ConnectionFactory
    {
        public RabbitMQConnection(string hostName, int port, string userName, string password)
        {
            HostName = hostName;
            Port = port;
            UserName = userName;
            Password = password;
            VirtualHost = "/";
        }
    }
}
