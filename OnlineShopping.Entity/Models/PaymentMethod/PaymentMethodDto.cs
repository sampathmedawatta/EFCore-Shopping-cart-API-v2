using System;
using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.PaymentMethod
{
    public class PaymentMethodDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
