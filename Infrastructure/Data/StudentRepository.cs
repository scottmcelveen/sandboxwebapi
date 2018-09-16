using SandboxWebAPI.Entities.StudentAggregate;
using SandboxWebAPI.Interfaces;

namespace SandboxWebAPI.Infrastructure.Data
{
    public class StudentRepository : EfRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}