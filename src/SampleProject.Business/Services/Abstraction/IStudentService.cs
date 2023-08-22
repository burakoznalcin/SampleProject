using SampleProject.Core.Business.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Student;
using SampleProject.Model.Model.Student;

namespace SampleProject.Business.Services.Abstraction
{
    public interface IStudentService : IBusinessService<StudentEntity, StudentModel, IStudentRepository, SampleProjectDbContext>
    {
    }
}
