using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("Category")]
    public class CategoryEntity : BaseEntity
    {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public ICollection<ProductEntiry> ProductEntities { get; set; }
    }
}
