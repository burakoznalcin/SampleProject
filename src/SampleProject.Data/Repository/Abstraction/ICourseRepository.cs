using SampleProject.Core.Data.Abstraction;
using SampleProject.Model.Entity.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Data.Repository.Abstraction
{
    public interface ICourseRepository : IRepositoryBase<CourseEntity>
    {
    }
}
