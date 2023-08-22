using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Data.Abstraction;
using SampleProject.Model.Entity.Base;
using SampleProject.Model.Utilities;

namespace SampleProject.Core.UnitOfWork.Abstraction
{
    public interface IUnitOfWork<TContext, TEntity, TRepository> : IDisposable
     where TContext : DbContext
     where TEntity : BaseEntity
     where TRepository : IRepositoryBase<TEntity>
    {
        TRepository Repository { get; }
        void CommitTransaction();
        DataResult SaveChanges();
    }
}
