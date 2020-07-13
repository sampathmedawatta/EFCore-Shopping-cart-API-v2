using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("UnitType")]
    public class UnitTypeEntity : BaseEntity
    {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
