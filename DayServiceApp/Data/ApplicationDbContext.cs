using Microsoft.EntityFrameworkCore;
using DayServiceApp.Models;

namespace DayServiceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
