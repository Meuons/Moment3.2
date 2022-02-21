
using Microsoft.EntityFrameworkCore;
using Moment3._2.Models;

namespace Moment_3._2.Data
{
    public class AlbumsContext : DbContext
    {

        public AlbumsContext(DbContextOptions<AlbumsContext> options) : base(options)

        {

        }

        public DbSet<Albums> Albums { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Genres> Genres { get; set; }
    }
}