using System;
using System.ComponentModel.DataAnnotations;

namespace Stone.AppStore.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        public User UserId { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Uf { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Avenue { get; set; }

        [Required]
        public int Number { get; set; }

        public string Complement { get; set; }
    }
}
