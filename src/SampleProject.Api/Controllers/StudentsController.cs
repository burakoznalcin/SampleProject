using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Business.Validation;
using SampleProject.Core.Utilities.Attributes;
using SampleProject.Model.Model.Student;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_studentService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentModel newModel)
        {
            StudentValidator validator = new StudentValidator();
            var validationResult = validator.Validate(newModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(_studentService.Add(newModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] StudentModel updateModel)
        {
            return Ok(_studentService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_studentService.DeleteById(id));
        }
    }
}
