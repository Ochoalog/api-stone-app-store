using System;
using System.ComponentModel.DataAnnotations;

namespace Stone.AppStore.Domain.Entities
{
    public class App : Base
    {
        [Required]
        public double Value { get; private set; }

        public string Creator { get; private set; }

        public App(Guid id,string name, bool active, double value, string creator)
        {
            Id = id;
            Name = name;
            Active = active;
            Value = value;
            Creator = creator;
        }
    }
}
