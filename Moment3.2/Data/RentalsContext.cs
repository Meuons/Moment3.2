
using Microsoft.EntityFrameworkCore;
using Moment3._2.Models;

namespace Moment_3._2.Data
{
    public class RentalsContext : DbContext
    {

        public RentalsContext(DbContextOptions<RentalsContext> options) : base(options)

        {

        }
        public DbSet<Albums> Albums { get; set; }

        public DbSet<Albums> Users { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
    }
}