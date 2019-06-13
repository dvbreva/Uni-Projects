using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Car : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Model { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public int HorsePower { get; set; }

        // makeid 
        public int MakeId { get; set; }
        public virtual Make Make { get; set; }

        // typeid
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
    }
}
