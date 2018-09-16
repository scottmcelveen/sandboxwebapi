using Microsoft.EntityFrameworkCore;
using SandboxWebAPI.Entities.StudentAggregate;

namespace SandboxWebAPI.Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}