using System;
using System.Text.Json.Serialization;
using static OnlineShopping.Common.Enums;

namespace OnlineShopping.Entity.Models.User
{
    public class UserGenericDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstName")]
        public Gender Gender { get; set; }
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
        [JsonIgnore]
        public Guid CustomerRoleId { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
