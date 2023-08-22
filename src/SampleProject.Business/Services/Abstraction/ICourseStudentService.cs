using SampleProject.Core.Business.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.CourseStudent;
using SampleProject.Model.Model.CourseStudent;

namespace SampleProject.Business.Services.Abstraction
{
    public interface ICourseStudentService : IBusinessService<CourseStudentEntity, CourseStudentModel, ICourseStudentRepository, SampleProjectDbContext>
    {
    }
}
