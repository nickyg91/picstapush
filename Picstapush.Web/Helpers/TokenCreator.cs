using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Picstapush.Dto.Dtos;
using Picstapush.Dto.Interfaces;
using Picstapush.Web.Configurations;

namespace Picstapush.Web.Helpers
{
    public static class TokenCreator
    {
        public static TokenDto CreateToken(IPicstapushUser user, JwtConfigurationOptions jwtOptions)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Signature));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(jwtOptions.Issuer, jwtOptions.Audience, signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(jwtOptions.ExpiresIn));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var tokenModel = new TokenDto
            {
                ExpiresAt = token.ValidTo,
                TokenString = tokenString,
                RefreshToken = Guid.NewGuid().ToString("N"),
                RefreshTokenExpiresAt = DateTime.Now.AddMinutes(31)
            };
            return tokenModel;
        }
    }
}
