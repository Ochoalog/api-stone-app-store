using MediatR;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Commands.PaymentCommands
{
    public class PaymentCommand : IRequest<bool>
    {
        public Payment Payload { get; set; }
    }
}
