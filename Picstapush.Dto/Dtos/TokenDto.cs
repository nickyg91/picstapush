using System;
using System.Collections.Generic;
using System.Text;
using Picstapush.Dto.Interfaces;

namespace Picstapush.Dto.Dtos
{
    public class TokenDto : IToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenString { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
