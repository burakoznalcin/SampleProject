using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SampleProject.Core.Data.Abstraction;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Model.Entity.Base;
using SampleProject.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.UnitOfWork.Concretion
{
    public class UnitOfWork<TContext, TEntity, TRepository> : IUnitOfWork<TContext, TEntity, TRepository>
       where TContext : DbContext
        where TEntity : BaseEntity
       where TRepository : IRepositoryBase<TEntity>
    {
        public DbContext Context { get; set; }

        public TRepository Repository { get; set; }

        protected List<DbContext> Contexts;

        private IDbContextTransaction _transaction;

        private List<IDbContextTransaction> _transactions = null;
        public UnitOfWork(IRepositoryBase<TEntity> repository)
        {
            Repository = (TRepository)repository;
            Context = (DbContext)Repository.GetType().GetProperty("_context").GetValue(Repository);
        }
        public void CommitTransaction()
        {
            if (_transaction is null)
                throw new Exception("Transaction bulunamadı");

            if (this._transactions is not null)
            {
                foreach (var transaction in this._transactions)
                {
                    transaction.Commit();
                }
            }
            else if (_transaction is not null)
            {
                _transaction.Commit();
            }
            if (_transaction != null || _transactions != null)
                Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            if (_transactions != null)
                _transactions.ForEach(trans => trans.Dispose());

            _transaction = null;
            _transactions = null;

            GC.SuppressFinalize(this);
        }

        public DataResult SaveChanges()
        {
            DataResult result = new DataResult();

            try
            {
                if (Context.SaveChanges() > 0)
                {
                    result.IsSuccess = true;
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMessages = new List<string> { "Bilinmeyen SaveChanges() hatası" };
                }
            }
            catch (DbUpdateException ex)
            {
                result.IsSuccess = false;
                Dispose();
                throw new Exception("UnitOfWork hatası" + ex);
            }

            return result;
        }
    }
}
