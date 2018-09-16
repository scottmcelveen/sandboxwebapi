using SandboxWebAPI.Interfaces;

namespace SandboxWebAPI.Entities.StudentAggregate
{
    public class Student : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}