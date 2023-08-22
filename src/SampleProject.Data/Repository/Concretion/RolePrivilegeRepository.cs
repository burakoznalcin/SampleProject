using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Data.Concretion.EF;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;
using System.Linq.Expressions;

namespace SampleProject.Data.Repository.Concretion
{
    public class RolePrivilegeRepository : EFRepositoryBase<RolePrivilegeEntity>, IRolePrivilegeRepository
    {
        private readonly SampleProjectDbContext _context;
        public RolePrivilegeRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
            _context= sampleProjectDbContext;
        }

        public override List<RolePrivilegeEntity> GetList(Expression<Func<RolePrivilegeEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            return _context.Set<RolePrivilegeEntity>().Where(filter).Include(x=> x.Privilege).Include(r => r.Role).ToList();
        }
    }
}
