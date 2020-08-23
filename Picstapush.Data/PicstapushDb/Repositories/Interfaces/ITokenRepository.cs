using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Picstapush.Data.PicstapushDb.Entities;

namespace Picstapush.Data.PicstapushDb.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        Task<Token> InsertToken(Token token);
        Task<Token> GetTokenByRefreshToken(string refreshToken);
        Task<Token> GetTokenByUserId(int userId);
        Task RemoveTokensByUser(int userId);
    }
}
