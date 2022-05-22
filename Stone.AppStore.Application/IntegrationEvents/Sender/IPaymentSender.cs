using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.IntegrationEvents.Sender
{
    public interface IPaymentSender
    {
        bool SendPayment(PaymentModel payment);
    }
}
