using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.User
{
    public class UserRegisterDto
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonIgnore]
        public UserCreateDto User { get; set; }
    }
}
