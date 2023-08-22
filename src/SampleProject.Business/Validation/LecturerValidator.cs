using FluentValidation;
using SampleProject.Model.Model.CourseStudent;
using SampleProject.Model.Model.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Validation
{
    public class LecturerValidator : AbstractValidator<LecturerModel>
    {
        public LecturerValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
