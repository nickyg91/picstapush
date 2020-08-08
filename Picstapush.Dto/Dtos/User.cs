using System;
using Picstapush.Dto.Interfaces;

namespace Picstapush.Dto.Dtos
{
    public class User : IPicstapushUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
