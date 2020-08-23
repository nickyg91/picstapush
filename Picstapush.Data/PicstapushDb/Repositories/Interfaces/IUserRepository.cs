using System.Threading.Tasks;
using Picstapush.Data.PicstapushDb.Entities;

namespace Picstapush.Data.PicstapushDb.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User AuthenticateUser(string username, string password);
        Task<int> InsertUser(User user);
        Task<User> GetUserById(int id);
        Task<User> FindUserByUsername(string username);
        bool CheckIfUserExistsForEmailOrUsername(string email, string username);
    }
}