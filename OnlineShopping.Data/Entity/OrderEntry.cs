using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("Order")]
    public class OrderEntry : BaseEntity
    {

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public Guid OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatusEntry OrderStatus { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        [Required]
        public double DiscountTotal { get; set; }
        [Required]
        public Guid PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethodEntry PaymentMethod { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerEntry Customer { get; set; }
        public ICollection<OrderItemEntry> OrderItemEntries { get; set; }

    }
}
