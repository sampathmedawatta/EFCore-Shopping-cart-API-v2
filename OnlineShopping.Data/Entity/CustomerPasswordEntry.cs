using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("CustomerPassword")]
    public class CustomerPasswordEntry : BaseEntity
    {

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerEntry Customer { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }


    }
}
