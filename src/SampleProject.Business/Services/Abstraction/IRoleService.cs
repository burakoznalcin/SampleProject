using SampleProject.Core.Business.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Model.Authorize;

namespace SampleProject.Business.Services.Abstraction
{
    public interface IRoleService : IBusinessService<RoleEntity, RoleModel, IRoleRepository, SampleProjectDbContext>
    {
    }
}
