using CurrenciesTaskApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesTaskApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Currencies> Currency { get; set; }

        public DbSet<Currencies_Ondate> Currencies_Ondates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Warning);
        }
    }
}
