using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxWebAPI.Entities.StudentAggregate;
using SandboxWebAPI.Interfaces;
using SandboxWebAPI.Specifications;
using SandboxWebAPI.ViewModels;
using X.PagedList;

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
        public IPagedList<StudentViewModel> Get(int? pageSize, int? pageNumber)
        {
            var filter = new StudentFilterSpecification(pageSize, pageNumber);
            var students = repository.List(filter);

            return students.Select(s => StudentViewModel.MapFrom(s));
        }
    }
}
