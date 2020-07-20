using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.User
{
    public class UserCreateDto : UserRegisterDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }



    }
}
