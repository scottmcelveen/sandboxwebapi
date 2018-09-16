using System.Threading.Tasks;
using SandboxWebAPI.Entities.StudentAggregate;

namespace SandboxWebAPI.Interfaces
{
    public interface IStudentRepository : IRepository<Student>, IAsyncRepository<Student>
    {
    }
}