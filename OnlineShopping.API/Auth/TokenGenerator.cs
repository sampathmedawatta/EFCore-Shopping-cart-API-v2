using Microsoft.IdentityModel.Tokens;
using OnlineShopping.API.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShopping.API.Auth
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public IDictionary<string, string> UsersRefreshTokens { get; set; }

        public TokenGenerator(IRefreshTokenGenerator refreshTokenGenerator)
        {
            _refreshTokenGenerator = refreshTokenGenerator;
            UsersRefreshTokens = new Dictionary<string, string>();
        }

        public AuthanticationResponse GenerateToken(string key, Claim[] _claims, string id)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                claims: _claims,
                expires: DateTime.UtcNow.AddMinutes(3),
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = _refreshTokenGenerator.GenerateToken();

            if (UsersRefreshTokens.ContainsKey(id))
            {
                UsersRefreshTokens[id] = refreshToken;
            }
            else
            {
                UsersRefreshTokens.Add(id.ToString(), refreshToken);
            }


            return new AuthanticationResponse
            {
                JwtToken = token,
                RefreshToken = refreshToken
            };
        }

        public AuthanticationResponse GenerateToken(string key, Guid id)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = _refreshTokenGenerator.GenerateToken();
            var token = tokenHandler.WriteToken(securityToken);

            if (UsersRefreshTokens.ContainsKey(id.ToString()))
            {
                UsersRefreshTokens[id.ToString()] = refreshToken;
            }
            else
            {
                UsersRefreshTokens.Add(id.ToString(), refreshToken);
            }

            return new AuthanticationResponse
            {
                JwtToken = token,
                RefreshToken = refreshToken
            };

        }
    }
}
