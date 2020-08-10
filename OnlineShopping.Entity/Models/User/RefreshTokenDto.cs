namespace OnlineShopping.Entity.Models.User
{
    public class RefreshTokenDto
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
