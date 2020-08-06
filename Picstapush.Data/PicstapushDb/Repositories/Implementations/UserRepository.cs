using System.Linq;
using System.Threading.Tasks;
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
        public User AuthenticateUser(string username, byte[] password)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public async Task<int> InsertUser(User user)
        {
            var insertedUser = await _context.Users.AddAsync(user);
            return insertedUser.Entity.Id;
        }
    }
}