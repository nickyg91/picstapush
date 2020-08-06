using System.Threading.Tasks;
using Picstapush.Data.PicstapushDb.Entities;

namespace Picstapush.Data.PicstapushDb.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User AuthenticateUser(string username, byte[] password);
        Task<int> InsertUser(User user);
    }
}