using SampleProject.Core.Data.Concretion.EF;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.CourseStudent;
using SampleProject.Model.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Data.Repository.Concretion
{
    public class CourseStudentRepository : EFRepositoryBase<CourseStudentEntity>, ICourseStudentRepository
    {
        public CourseStudentRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
        }
    }
}
