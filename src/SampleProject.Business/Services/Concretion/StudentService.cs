using AutoMapper;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Business.Concretion;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Student;
using SampleProject.Model.Model.Student;

namespace SampleProject.Business.Services.Concretion
{
    public class StudentService : BusinessService<StudentEntity, StudentModel, IStudentRepository, SampleProjectDbContext>, IStudentService
    {
        public StudentService(IUnitOfWork<SampleProjectDbContext, StudentEntity, IStudentRepository> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
