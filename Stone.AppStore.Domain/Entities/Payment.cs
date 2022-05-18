using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public CreditCard CreditCard { get; set; }

        public Guid AppId { get; set; }

        public Guid UserId { get; set; }
    }
}
