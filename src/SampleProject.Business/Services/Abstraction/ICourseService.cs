using SampleProject.Core.Business.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Model.Course;

namespace SampleProject.Business.Services.Abstraction
{
    public interface ICourseService : IBusinessService<CourseEntity, CourseModel, ICourseRepository, SampleProjectDbContext>
    {
    }
}
