using AutoMapper;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Business.Concretion;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Model.Course;

namespace SampleProject.Business.Services.Concretion
{
    public class CourseService : BusinessService<CourseEntity, CourseModel, ICourseRepository, SampleProjectDbContext>, ICourseService
    {
        public CourseService(IUnitOfWork<SampleProjectDbContext, CourseEntity, ICourseRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
