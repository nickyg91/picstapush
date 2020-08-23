using Microsoft.EntityFrameworkCore;
using Picstapush.Data.PicstapushDb.Entities;

namespace Picstapush.Data.PicstapushDb
{
    public class PicstapushDbContext : DbContext
    {
        public PicstapushDbContext(DbContextOptions<PicstapushDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}