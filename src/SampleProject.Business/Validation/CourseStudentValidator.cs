using FluentValidation;
using SampleProject.Model.Model.CourseStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Validation
{
    public class CourseStudentValidator : AbstractValidator<CourseStudentModel>
    {
        public CourseStudentValidator()
        {
            RuleFor(x => x.StudentId).NotNull().NotEmpty();
            RuleFor(x => x.CourseId).NotNull().NotEmpty();
        }
    }
}
