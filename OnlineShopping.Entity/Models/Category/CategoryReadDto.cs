﻿using System;

namespace OnlineShopping.Entity.Models.Category
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
