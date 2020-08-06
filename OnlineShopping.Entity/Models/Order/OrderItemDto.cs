using System;
using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.Order
{
    public class OrderItemDto
    {

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("qty")]
        public int Qty { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }

    }
}
