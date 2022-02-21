
using Microsoft.EntityFrameworkCore;
using Moment3._2.Models;

namespace Moment_3._2.Data
{
    public class UsersContext : DbContext
    {

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)

        {

        }

        public DbSet<Users> Users { get; set; }
    }
}