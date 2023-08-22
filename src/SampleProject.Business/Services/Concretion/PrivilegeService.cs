using AutoMapper;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Business.Concretion;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Model.Authorize;

namespace SampleProject.Business.Services.Concretion
{
    public class PrivilegeService : BusinessService<PrivilegeEntity, PrivilegeModel, IPrivilegeRepository, SampleProjectDbContext>, IPrivilegeService
    {
        public PrivilegeService(IUnitOfWork<SampleProjectDbContext, PrivilegeEntity, IPrivilegeRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
