﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }

        public string Cep { get; set; }

        public string Uf { get; set; }

        public string City { get; set; }

        public string Avenue { get; set; }

        public int Number { get; set; }

        public string Complement { get; set; }
    }
}
