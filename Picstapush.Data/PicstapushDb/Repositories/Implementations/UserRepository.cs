using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Picstapush.Data.PicstapushDb.Entities;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;

namespace Picstapush.Data.PicstapushDb.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly PicstapushDbContext _context;
        public UserRepository(PicstapushDbContext context)
        {
            _context = context;
        }
        public User AuthenticateUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public async Task<int> InsertUser(User user)
        {
            var insertedUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return insertedUser.Entity.Id;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}