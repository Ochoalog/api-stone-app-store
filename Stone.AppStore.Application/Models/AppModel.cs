using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Models
{
    public class AppModel
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public double Value { get; set; }

        public string Creator { get; set; }
    }
}
