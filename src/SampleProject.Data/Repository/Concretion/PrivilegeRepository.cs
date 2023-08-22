using SampleProject.Core.Data.Concretion.EF;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;

namespace SampleProject.Data.Repository.Concretion
{
    public class PrivilegeRepository : EFRepositoryBase<PrivilegeEntity>, IPrivilegeRepository
    {
        public PrivilegeRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
        }
    }
}
