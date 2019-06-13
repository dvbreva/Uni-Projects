using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Type : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(400)]
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
