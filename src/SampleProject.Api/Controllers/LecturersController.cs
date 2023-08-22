using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Business.Validation;
using SampleProject.Model.Model.Lecturer;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;

        public LecturersController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_lecturerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_lecturerService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] LecturerModel newModel)
        {
            LecturerValidator validator = new LecturerValidator();
            var validationResult = validator.Validate(newModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(_lecturerService.Add(newModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] LecturerModel updateModel)
        {
            return Ok(_lecturerService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_lecturerService.DeleteById(id));
        }
    }
}
