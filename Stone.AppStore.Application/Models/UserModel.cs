using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public AddressModel Address { get; set; }
    }
}
