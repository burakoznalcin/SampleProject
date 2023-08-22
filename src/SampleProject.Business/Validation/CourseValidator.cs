using FluentValidation;
using SampleProject.Model.Model.Course;
using SampleProject.Model.Model.CourseStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Validation
{
    public class CourseValidator : AbstractValidator<CourseModel>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.LecturerId).NotNull().NotEmpty();
        }
    }
}
