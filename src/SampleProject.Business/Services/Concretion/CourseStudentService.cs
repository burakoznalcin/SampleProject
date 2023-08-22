using AutoMapper;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Business.Concretion;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.CourseStudent;
using SampleProject.Model.Model.CourseStudent;

namespace SampleProject.Business.Services.Concretion
{
    public class CourseStudentService : BusinessService<CourseStudentEntity, CourseStudentModel, ICourseStudentRepository, SampleProjectDbContext>, ICourseStudentService
    {
        public CourseStudentService(IUnitOfWork<SampleProjectDbContext, CourseStudentEntity, ICourseStudentRepository> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
