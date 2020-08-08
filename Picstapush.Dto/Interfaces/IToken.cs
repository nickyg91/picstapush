using System;
using System.Collections.Generic;
using System.Text;

namespace Picstapush.Dto.Interfaces
{
    public interface IToken
    {
        int Id { get; }
        int UserId { get; }
        string TokenString { get; }
        string RefreshToken { get; }
        DateTime ExpiresAt { get; }
    }
}
