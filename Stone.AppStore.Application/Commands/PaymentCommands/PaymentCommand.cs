using MediatR;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Commands.PaymentCommands
{
    public class PaymentCommand : IRequest<bool>
    {
        public PaymentModel Payload { get; set; }
    }
}
