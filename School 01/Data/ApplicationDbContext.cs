using Microsoft.EntityFrameworkCore;
using School_01.Models;

namespace School_01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
    }
}
