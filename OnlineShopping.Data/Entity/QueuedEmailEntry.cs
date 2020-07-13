using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("QueueEmail")]
    public class QueuedEmailEntry : BaseEntity
    {

        public Guid? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderEntry Order { get; set; }
        [MaxLength(250)]
        public string From { get; set; }
        [MaxLength(250)]
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
