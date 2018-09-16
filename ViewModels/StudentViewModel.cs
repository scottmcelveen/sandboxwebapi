using SandboxWebAPI.Entities.StudentAggregate;

namespace SandboxWebAPI.ViewModels
{
    public class StudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static StudentViewModel MapFrom(Student student)
        {
            return new StudentViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
        }
    }
}