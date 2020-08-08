using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Picstapush.Utilities.AuthenticationHelpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool MatchPassword(string fromDb, string password)
        {
            var matches = BCrypt.Net.BCrypt.Verify(password, fromDb);
            return matches;
        }
    }
}