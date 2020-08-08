using System;

namespace Picstapush.Dto.Interfaces
{
    public interface IPicstapushUser
    {
        int Id { get; }
        string Email { get; }
        string Username { get; }
        string Password { get; }
        DateTime DateCreated { get; }
    }
}