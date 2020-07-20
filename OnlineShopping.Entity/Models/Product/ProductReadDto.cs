using System;
using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.Product
{
    public class ProductReadDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

    }
}
