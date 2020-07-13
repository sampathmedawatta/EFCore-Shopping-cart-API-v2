using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("Customer")]
    public class CustomerEntry : BaseEntity
    {

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        public DateTime RegisteredDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(15)]
        public string State { get; set; }
        public int PostCode { get; set; }

        [Required]
        public Guid CustomerRoleId { get; set; }
        [ForeignKey("CustomerRoleId")]
        public CustomerRoleEntry CustomerRole { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
    public enum Gender
    {
        M, F
    }
}
