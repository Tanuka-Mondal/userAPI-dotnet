
using Microsoft.EntityFrameworkCore;
using UserAPI_Tanuka.Models;

namespace UserAPI_Tanuka.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
    }
}
