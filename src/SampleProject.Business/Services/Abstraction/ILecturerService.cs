using SampleProject.Core.Business.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Lecturer;
using SampleProject.Model.Model.Lecturer;

namespace SampleProject.Business.Services.Abstraction
{
    public interface ILecturerService : IBusinessService<LecturerEntity, LecturerModel, ILecturerRepository, SampleProjectDbContext>
    {
    }
}
