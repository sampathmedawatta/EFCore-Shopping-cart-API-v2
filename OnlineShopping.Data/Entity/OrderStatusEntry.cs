using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("OrderStatus")]
    public class OrderStatusEntry : BaseEntity
    {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
