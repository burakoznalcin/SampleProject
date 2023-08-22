using FluentValidation;
using SampleProject.Model.Model.Student;

namespace SampleProject.Business.Validation
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
        public StudentValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
