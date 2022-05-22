using MediatR;
using Serilog;
using Stone.AppStore.Application.IntegrationEvents.Sender;
using Stone.AppStore.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Commands.PaymentCommands
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCommand, bool>
    {
        private readonly IPaymentSender _paymentSender;

        public PaymentCommandHandler(IPaymentSender paymentSender)
        {
            _paymentSender = paymentSender;
        }

        public async Task<bool> Handle(PaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return _paymentSender.SendPayment(request.Payload);               
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }
        }
    }
}
