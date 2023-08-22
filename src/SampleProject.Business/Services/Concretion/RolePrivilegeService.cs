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
    public class RolePrivilegeService : BusinessService<RolePrivilegeEntity, RolePrivilegeModel, IRolePrivilegeRepository, SampleProjectDbContext>, IRolePrivilegeService
    {
        public RolePrivilegeService(IUnitOfWork<SampleProjectDbContext, RolePrivilegeEntity, IRolePrivilegeRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
