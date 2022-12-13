using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
