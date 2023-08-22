using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Data.Abstraction;
using SampleProject.Model.Entity.Base;
using SampleProject.Model.Model.Base;
using SampleProject.Model.Utilities;
using System.Linq.Expressions;

namespace SampleProject.Core.Business.Abstraction
{
    public interface IBusinessService<TEntity, TModel, TRepository, TContext>
       where TModel : BaseModel
       where TEntity : BaseEntity
       where TContext : DbContext
       where TRepository : IRepositoryBase<TEntity>
    {
        List<TModel> GetAll();
        List<TModel> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false);
        DataResult GetById(long Id);
        DataResult Add(TModel model);
        DataResult Update(TModel model, bool deletion = false);
        DataResult DeleteById(long Id);
    }
}
