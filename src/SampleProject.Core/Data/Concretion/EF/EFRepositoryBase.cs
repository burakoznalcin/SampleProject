using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Data.Abstraction;
using SampleProject.Model.Entity.Base;
using System.Linq.Expressions;
using System.Net;

namespace SampleProject.Core.Data.Concretion.EF
{
    public class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
    {
        public DbContext _context { get; set; }
        public EFRepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        protected DbSet<TEntity> _dbSet;
        public TEntity Entity { get; set; }

        public TEntity GetById(long id, bool ShowDeleted = false)
        {
            if (id != null)
            {
                if (ShowDeleted == false)
                {
                    return _context.Set<TEntity>().Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
                }
                else
                {
                    return _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault()!;
                }
            }
            throw new Exception("Id is Null", new Exception(HttpStatusCode.BadRequest.ToString()));
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            return filter == null
               ? _context.Set<TEntity>().ToList()
               : _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);

            this.Entity = entity;
        }

        public void Delete(long id)
        {
            TEntity entity = GetById(id, true);

            if (entity == null)
                throw new Exception("Silinecek öğe bulunamadı", new Exception(HttpStatusCode.BadRequest.ToString()));

            entity.IsDeleted = true;

            this.Update(entity, deletion: true);
        }

        public void Update(TEntity entity, bool deletion = false)
        {
            if (entity == null)
            {
                throw new Exception("Güncellenecek öğe bulunamadı", new Exception(HttpStatusCode.BadRequest.ToString()));
            }
            entity.IsDeleted = deletion;
            _dbSet.Update(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking<TEntity>().Where(x => !x.IsDeleted);
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }
    }
}
