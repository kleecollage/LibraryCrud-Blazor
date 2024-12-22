using LibraryCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryCrud.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    // MODELS
    public DbSet<Book> Books { get; set; }
}