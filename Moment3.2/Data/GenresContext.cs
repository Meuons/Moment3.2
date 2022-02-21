
using Microsoft.EntityFrameworkCore;
using Moment3._2.Models;

namespace Moment_3._2.Data
{
    public class GenresContext : DbContext
    {

        public GenresContext(DbContextOptions<GenresContext> options) : base(options)

        {

        }

        public DbSet<Genres> Genres { get; set; }
    }
}