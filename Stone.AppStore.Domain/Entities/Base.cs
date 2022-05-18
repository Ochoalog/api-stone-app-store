using System;

namespace Stone.AppStore.Domain.Entities
{
    public class Base
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
