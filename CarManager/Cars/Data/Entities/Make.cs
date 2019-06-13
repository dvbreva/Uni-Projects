using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Make : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
