using System.Linq.Expressions;

namespace SampleProject.Core.Data.Abstraction
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(long id, bool ShowDeleted = false);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Delete(long id);
        void Update(TEntity entity, bool deletion = false);
        public IQueryable<TEntity> GetAll();
    }
}
