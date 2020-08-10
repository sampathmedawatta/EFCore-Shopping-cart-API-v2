using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace OnlineShopping.API.Auth.Interfaces
{
    public interface ITokenGenerator
    {
        AuthanticationResponse GenerateToken(string key, Guid id);
        AuthanticationResponse GenerateToken(string key, Claim[] _claims, string id);
        IDictionary<string, string> UsersRefreshTokens { get; set; }
    }
}
