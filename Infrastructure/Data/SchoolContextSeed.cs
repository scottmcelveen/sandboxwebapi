using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxWebAPI.Entities.StudentAggregate;

namespace SandboxWebAPI.Infrastructure.Data
{
    public class SchoolContextSeed
    {
        public static async Task SeedAsync(SchoolContext schoolContext)
        {
            if (!schoolContext.Students.Any())
            {
                schoolContext.Students.AddRange(
                    GetPreconfiguredStudents());
                    await schoolContext.SaveChangesAsync();
            }
        }

        static IEnumerable<Student> GetPreconfiguredStudents()
        {
            return new List<Student>()
            {
                new Student() { FirstName = "Scott", LastName = "McElveen" },
                new Student() { FirstName = "Amanda", LastName = "McElveen" },
            };
        }
    }
}