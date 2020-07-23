using System;
using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.Category
{
    public class CategoryDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
