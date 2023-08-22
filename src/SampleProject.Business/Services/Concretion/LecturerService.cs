using AutoMapper;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Business.Concretion;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Lecturer;
using SampleProject.Model.Model.Lecturer;

namespace SampleProject.Business.Services.Concretion
{
    public class LecturerService : BusinessService<LecturerEntity, LecturerModel, ILecturerRepository, SampleProjectDbContext>, ILecturerService
    {
        public LecturerService(IUnitOfWork<SampleProjectDbContext, LecturerEntity, ILecturerRepository> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
