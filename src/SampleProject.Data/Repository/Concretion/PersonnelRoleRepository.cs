using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Data.Concretion.EF;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;
using System.Linq.Expressions;

namespace SampleProject.Data.Repository.Concretion
{
    public class PersonnelRoleRepository : EFRepositoryBase<PersonnelRoleEntity>, IPersonnelRoleRepository
    {
        private new readonly SampleProjectDbContext _context;
        public PersonnelRoleRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
            _context = sampleProjectDbContext;
        }

        public override List<PersonnelRoleEntity> GetList(Expression<Func<PersonnelRoleEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            return _context.PersonnelRoleEntities.Where(filter).Include(x=> x.Personnel).Include(r => r.Role).ToList();
        }
    }
}
