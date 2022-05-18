using Microsoft.AspNetCore.Identity;
using Stone.AppStore.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stone.AppStore.Infraestructure.Identity
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        public bool Active { get; set; }

        public Address Address { get; set; }
    }
}
