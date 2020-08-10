using OnlineShopping.Entity.Models.User;

namespace OnlineShopping.API.Auth.Interfaces
{
    public interface ITokenRefresher
    {
        AuthanticationResponse Refresh(RefreshTokenDto refreshTokenDto, string key);
    }
}