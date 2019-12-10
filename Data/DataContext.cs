using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class DataContext : DbContext
    {
        // public DataContext(DbContextOptions<DataContext> options) : base(options)
        // {

        // }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=DESKTOP-RHN6S6D\SQLEXPRESS;Database=Shop;User Id=SA;Password=123");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}