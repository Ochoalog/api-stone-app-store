using System;
using System.ComponentModel.DataAnnotations;

namespace Stone.AppStore.Domain.Entities
{
    public class CreditCard : Base
    {
        [Required]
        [CreditCard]
        public string Number { get; set; }

        [Required]
        public DateTime ValidateTime { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
