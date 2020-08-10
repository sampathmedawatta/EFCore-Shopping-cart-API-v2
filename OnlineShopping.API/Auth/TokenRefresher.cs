using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.API.Auth.Interfaces;
using OnlineShopping.Entity.Models;
using OnlineShopping.Entity.Models.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace OnlineShopping.API.Auth
{
    public class TokenRefresher : ITokenRefresher
    {

        private readonly ITokenGenerator _tokenGenerator;
        private readonly ApplicationSettings _appsettings;

        public TokenRefresher(IOptions<ApplicationSettings> appsettings, ITokenGenerator tokenGenerator)
        {

            _tokenGenerator = tokenGenerator;
            _appsettings = appsettings.Value;
        }
        public AuthanticationResponse Refresh(RefreshTokenDto refreshTokenDto, string key)
        {
            // var key = Encoding.UTF8.GetBytes(_appsettings.JWT_Secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(refreshTokenDto.JwtToken,
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token Passed.");
            }

            var userId = principal.Identity.Name;

            var aa = _tokenGenerator.UsersRefreshTokens;
            if (refreshTokenDto.RefreshToken != _tokenGenerator.UsersRefreshTokens[userId])
            {
                throw new SecurityTokenException("Invalid Token Passed.");
            }

            return _tokenGenerator.GenerateToken(key, principal.Claims.ToArray(), userId);

        }
    }
}
