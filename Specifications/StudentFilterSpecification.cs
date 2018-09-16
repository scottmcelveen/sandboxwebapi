using SandboxWebAPI.Entities.StudentAggregate;

namespace SandboxWebAPI.Specifications
{
    public class StudentFilterSpecification : BaseSpecification<Student>
    {
        public StudentFilterSpecification() : base(s => true)
        {
            
        }
    }
}