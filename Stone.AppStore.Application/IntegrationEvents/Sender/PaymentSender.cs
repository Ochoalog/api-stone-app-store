using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;
using Stone.AppStore.Application.IntegrationEvents.Options;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using System;
using System.Text;

namespace Stone.AppStore.Application.IntegrationEvents.Sender
{
    public class PaymentSender : IPaymentSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private IConnection _connection;

        public PaymentSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;

            CreateConnection();
        }

        public bool SendPayment(PaymentModel payment)
        {
            try
            {
                if(payment.PaymentMethod == Domain.Enums.PaymentMethodEnum.CreditCard)
                {
                    if (ConnectionExists())
                    {
                        using (var channel = _connection.CreateModel())
                        {
                            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                            var json = JsonConvert.SerializeObject(payment);
                            var body = Encoding.UTF8.GetBytes(json);

                            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }
            
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Log.Logger.Error( $"Could not create connection: {ex}");
                throw ex;
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}
