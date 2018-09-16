using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxWebAPI.Entities.StudentAggregate;
using SandboxWebAPI.Interfaces;
using SandboxWebAPI.ViewModels;

namespace SandboxWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository repository;

        public StudentsController(IStudentRepository repository)
        {
            this.repository = repository;
        }
        
        // GET api/students
        [HttpGet]
        public IEnumerable<StudentViewModel> Get()
        {
            var students = repository.ListAll();

            return students.Select(s => StudentViewModel.MapFrom(s));
        }
    }
}
