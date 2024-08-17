
using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        //Marks an bulk entity as new
        Task BulkAdd(IEnumerable<T> entities);
        // Marks an entity as new
        Task Add(T entity);
        // Marks an entity as modified
        Task Update(T entity);
        // Marks an entity to be removed
        Task Delete(T entity);
        Task Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        Task<T> GetById(string id);
        // Get an entity using delegate
        Task<T> Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        Task<IEnumerable<T>> GetAll();
        // Gets entities using delegate
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where);
        // Gets total count of type T
        Task<int> GetTotalCount();
        //gets all with pagination of type T
        Task<IEnumerable<T>> GetAllWithPagination(int pageNumber, int pageSize);
    }

    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private WebAPIDbContext? dataContext;
        public readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected WebAPIDbContext ExamDbContext
        {
            get { return dataContext ??= DbFactory.Init(); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = ExamDbContext.Set<T>();
        }

        #region Implementation
        public virtual async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task BulkAdd(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public virtual async Task Update(T entity)
        {
            //expecting dataContext is non-nullable
            dataContext.ChangeTracker.Clear();
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual async Task<T?> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> where)
        {
            return await dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalCount()
        {
            return await dbSet.CountAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return await dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion
    }
}