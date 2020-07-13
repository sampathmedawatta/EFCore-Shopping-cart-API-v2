using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Data.Entity
{
    [Table("Product")]
    public class ProductEntiry : BaseEntity
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double StockQty { get; set; }
        [Required]
        public bool StockAvailability { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double SellingPrice { get; set; }

        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool ShowInHomePage { get; set; }
        [Required]
        public bool IsFeatureProduct { get; set; }
        [Required]
        public Guid UnitTypeId { get; set; }
        [ForeignKey("UnitTypeId")]
        public UnitTypeEntity UnitType { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryEntity Category { get; set; }
        public Guid PictureId { get; set; }
        [ForeignKey("PictureId")]
        public PictureEntity Picture { get; set; }
    }
}
