namespace OnlineShopping.API.Auth
{
    public class AuthanticationResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
