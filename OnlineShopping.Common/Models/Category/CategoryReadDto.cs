using System;

namespace OnlineShopping.Common.Models.Category
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
