using SandboxWebAPI.Entities.StudentAggregate;

namespace SandboxWebAPI.Specifications
{
    public class StudentFilterSpecification : BaseSpecification<Student>
    {
        public StudentFilterSpecification() : base(s => s.FirstName.Contains("Scott"))
        {

        }

        public StudentFilterSpecification(int? pageSize, int? pageNumber) : base(s => s.FirstName.Contains("Scott"), pageSize, pageNumber)
        {
            
        }
    }
}