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
                new Student() { FirstName = "Scott1", LastName = "McElveen" },
                new Student() { FirstName = "Scott2", LastName = "McElveen" },
                new Student() { FirstName = "Scott3", LastName = "McElveen" },
                new Student() { FirstName = "Scott4", LastName = "McElveen" },
                new Student() { FirstName = "Scott5", LastName = "McElveen" },
                new Student() { FirstName = "Scott6", LastName = "McElveen" },
                new Student() { FirstName = "Scott7", LastName = "McElveen" },
                new Student() { FirstName = "Scott8", LastName = "McElveen" },
                new Student() { FirstName = "Scott9", LastName = "McElveen" },
                new Student() { FirstName = "Scott10", LastName = "McElveen" },
                new Student() { FirstName = "Scott11", LastName = "McElveen" },
                new Student() { FirstName = "Amanda", LastName = "McElveen" },
            };
        }
    }
}