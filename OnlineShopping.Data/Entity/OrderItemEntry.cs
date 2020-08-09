using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("OrderItem")]
    public class OrderItemEntry : BaseEntity
    {

        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderEntry Order { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductEntiry Product { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double Discount { get; set; }
    }
}
