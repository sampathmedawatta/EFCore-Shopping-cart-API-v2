using System;
using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.Order
{
    public class DeliveryDetailsDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstName")]

        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("postCode")]
        public int PostCode { get; set; }
    }
}
