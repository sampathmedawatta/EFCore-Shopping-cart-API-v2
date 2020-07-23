using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.User
{
    public class CustomerDto : UserDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

    }
}
