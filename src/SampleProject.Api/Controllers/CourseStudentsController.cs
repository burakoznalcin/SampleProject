using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Business.Validation;
using SampleProject.Model.Model.CourseStudent;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentsController : ControllerBase
    {
        private readonly ICourseStudentService _courseStudentService;
        public CourseStudentsController(ICourseStudentService courseStudentService)
        {
            _courseStudentService = courseStudentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_courseStudentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_courseStudentService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseStudentModel newModel)
        {
            CourseStudentValidator validator = new CourseStudentValidator();
            var validationResult = validator.Validate(newModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(_courseStudentService.Add(newModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] CourseStudentModel updateModel)
        {
            return Ok(_courseStudentService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_courseStudentService.DeleteById(id));
        }
    }
}
