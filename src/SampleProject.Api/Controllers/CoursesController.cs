using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Business.Validation;
using SampleProject.Core.Utilities.Attributes;
using SampleProject.Model.Model.Course;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HasPermission]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_courseService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_courseService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseModel newModel)
        {
            CourseValidator validator = new CourseValidator();
            var validationResult = validator.Validate(newModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(_courseService.Add(newModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] CourseModel updateModel)
        {
            return Ok(_courseService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_courseService.DeleteById(id));
        }
    }
}
