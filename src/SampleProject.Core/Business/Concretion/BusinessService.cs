using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Business.Abstraction;
using SampleProject.Core.Data.Abstraction;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Model.Entity.Base;
using SampleProject.Model.Model.Base;
using SampleProject.Model.Utilities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SampleProject.Core.Business.Concretion
{
    public class BusinessService<TEntity, TModel, TRepository, TContext> : IBusinessService<TEntity, TModel, TRepository, TContext>
        where TModel : BaseModel
        where TEntity : BaseEntity
        where TContext : DbContext
        where TRepository : IRepositoryBase<TEntity>
    {
        public readonly IUnitOfWork<TContext, TEntity, TRepository> _uow;
        public readonly IMapper _mapper;
        public BusinessService(IUnitOfWork<TContext, TEntity, TRepository> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public virtual DataResult Add(TModel model)
        {
            #region StopWatch

#if (DEBUG)

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

#endif
            #endregion

            TEntity entity = _mapper.Map<TEntity>(model);

            _uow.Repository.Add(entity);


            #region StopWatch
#if (DEBUG)

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var className = assembly.GetName().Name;

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.Add  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif

            #endregion

            var result = _uow.SaveChanges();

            #region StopWatch
#if (DEBUG)


            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => UnitOfWork.SaveChanges  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif

            #endregion


            if (result.IsSuccess)
            {
                result.PkId = entity.Id;
                model.Id = entity.Id;

                result.Data = model;
                #region StopWatch

#if (DEBUG)

                Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => UnitOfWork.CommitTransaction  {watch.ElapsedMilliseconds} ms");
                watch.Stop();

#endif

                #endregion

            }
            return result;
        }

        public virtual DataResult DeleteById(long Id)
        {
            #region StopWatch

#if (DEBUG)
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();


#endif       
            #endregion

            TEntity entity = _uow.Repository.GetById(Id);

            #region StopWatch

#if (DEBUG)

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var className = assembly.GetName().Name;

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.GetById  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif    
            #endregion


            if (entity == null)
            {
                return new DataResult
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string> { "Silinecek öğe bulunamadı" }
                };
            }


            _uow.Repository.Delete(Id);

            #region StopWatch


#if (DEBUG)

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.Delete  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif

            #endregion

            var result = _uow.SaveChanges();

            if (result.IsSuccess)
            {
                #region StopWatch

#if (DEBUG)

                Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => UnitOfWork.CommitTransaction  {watch.ElapsedMilliseconds} ms");
                watch.Stop();

#endif

                #endregion
            }


            return result;
        }

        public virtual List<TModel> GetAll()
        {

            #region StopWatch

#if (DEBUG)

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

#endif
            #endregion

            IQueryable<TEntity> rawData = _uow.Repository.GetAll();


            #region StopWatch
#if (DEBUG)

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var className = assembly.GetName().Name;

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.GetAll  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif
            #endregion

            List<TModel> sourceData = _mapper.Map<List<TModel>>(rawData);

#if (DEBUG)

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => LookupHelper.MappingResolver  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();
#endif

#if (DEBUG)

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => this.FieldCleaner  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();
#endif

            return sourceData;
        }

        public virtual DataResult GetById(long Id)
        {
            #region StopWatch

#if (DEBUG)

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

#endif
            #endregion

            List<TModel> models = new List<TModel>();

            TEntity rawData = _uow.Repository.GetById(Id);

            #region StopWatch
#if (DEBUG)

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var className = assembly.GetName().Name;

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.GetById  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif
            #endregion

            TModel model = _mapper.Map<TModel>(rawData);

            if (model != null)
            {
                models.Add(model);

                #region StopWatch
#if (DEBUG)


                Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => LookupHelper.MappingResolver {watch.ElapsedMilliseconds} ms");
                watch.Stop();

#endif
                #endregion

            }
            else
            {
                return new DataResult
                {
                    Data = model,
                    IsSuccess = false
                };
            }
            return new DataResult { Data = model };
        }

        public virtual List<TModel> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            #region StopWatch

#if (DEBUG)

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

#endif
            #endregion

            //filter = filter.AndAlso<TEntity>(x => FetchDeletedRows ? true : x.IsDeleted == true);

            List<TEntity> rawData = _uow.Repository.GetList(filter);


            #region StopWatch
#if (DEBUG)

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var className = assembly.GetName().Name;

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.GetList  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif
            #endregion

            List<TModel> sourceData = _mapper.Map<List<TModel>>(rawData);

#if (DEBUG)

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => LookupHelper.MappingResolver  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();
#endif


#if (DEBUG)

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => this.FieldCleaner  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();
#endif
            return sourceData;
        }

        public virtual DataResult Update(TModel model, bool deletion = false)
        {
            #region StopWatch

#if (DEBUG)

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

#endif
            #endregion


            TEntity Entity = _mapper.Map<TEntity>(model);

            _uow.Repository.Update(Entity, deletion);

            #region StopWatch
#if (DEBUG)

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var className = assembly.GetName().Name;

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => Repository.Update  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif
            #endregion

            var result = _uow.SaveChanges();

            #region StopWatch
#if (DEBUG)

            Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => UnitOfWork.SaveChanges  {watch.ElapsedMilliseconds} ms");
            watch.Stop();
            watch.Start();

#endif
            #endregion

            if (result.IsSuccess)
            {
                #region StopWatch
#if (DEBUG)

                Debug.WriteLine($"Execution Time: {className}.{_uow.Repository.GetType().Name} => UnitOfWork.CommitTransaction  {watch.ElapsedMilliseconds} ms");
                watch.Stop();

#endif
                #endregion

                result.PkId = Entity.Id;
                result.Data = model;
            }
            return result;
        }
    }
}
