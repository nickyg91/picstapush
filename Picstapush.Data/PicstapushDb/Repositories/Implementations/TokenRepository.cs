using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Picstapush.Data.PicstapushDb.Entities;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;

namespace Picstapush.Data.PicstapushDb.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly PicstapushDbContext _db;
        public TokenRepository(PicstapushDbContext context)
        {
            _db = context;
        }

        public async Task<Token> InsertToken(Token token)
        {
            await RemoveTokensByUser(token.UserId);
            var insertedToken = await _db.Tokens.AddAsync(token);
            await _db.SaveChangesAsync();
            return insertedToken.Entity;
        }

        public async Task<Token> GetTokenByRefreshToken(string refreshToken)
        {
            var token = await _db.Tokens.OrderByDescending(x => x.RefreshTokenExpiresAt).FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            return token;
        }

        public async Task<Token> GetTokenByUserId(int userId)
        {
            var token = await _db.Tokens.OrderByDescending(x => x.RefreshTokenExpiresAt).FirstOrDefaultAsync(x => x.UserId == userId);
            return token;
        }

        public async Task RemoveTokensByUser(int userId)
        {
            var tokens = _db.Tokens.Where(x => x.UserId == userId);
            _db.Tokens.RemoveRange(tokens);
            await _db.SaveChangesAsync();
        }
    }
}
