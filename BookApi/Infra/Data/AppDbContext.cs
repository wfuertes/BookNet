using BookApi.Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Infra.Data;

public class AppDbContext : DbContext
{
    private readonly bool _inMemory;
    
    public AppDbContext(bool inMemory = false)
    {
        _inMemory = inMemory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_inMemory)
        {
            optionsBuilder.UseInMemoryDatabase("bookstore");
            return;
        }
        optionsBuilder.UseMySql("Server=localhost;Database=bookstore;User=root;Password=root;", 
            new MySqlServerVersion(new Version(8, 1, 0)));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().ToTable("books");
    }

    public DbSet<Book> Books { get; set; } = null!;
}