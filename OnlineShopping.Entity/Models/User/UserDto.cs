using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.User
{
    public class UserDto
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonIgnore]
        public int PasswordFormatId { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        [JsonPropertyName("user")]
        public CustomerDto User { get; set; }
    }
}
