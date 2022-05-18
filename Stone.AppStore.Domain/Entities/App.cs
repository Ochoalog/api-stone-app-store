using System.ComponentModel.DataAnnotations;

namespace Stone.AppStore.Domain.Entities
{
    public class App : Base
    {
        [Required]
        public double Value { get; set; }

        public string Creator { get; set; }
    }
}
