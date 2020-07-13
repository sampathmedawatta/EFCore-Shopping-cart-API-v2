using System;

namespace OnlineShopping.Common.Models.Product
{
    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
