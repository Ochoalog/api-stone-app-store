using AutoMapper.Configuration.Annotations;
using Stone.AppStore.Domain.Enum;
using Stone.AppStore.Domain.Enums;
using System;

namespace Stone.AppStore.Application.Models
{
    public class PaymentModel
    {
        public Guid AppId { get; set; }

        public Guid UserId { get; set; }

        public CreditCardModel CreditCard { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; }

        [Ignore]
        public ResultConfirmationEnum ResultConfirmation { get; set; }

        [Ignore]
        public string Message { get; set; }
    }
}
