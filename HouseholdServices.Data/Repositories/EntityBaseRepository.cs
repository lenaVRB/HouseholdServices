using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HouseholdServices.Entities;
using HouseholdServices.Data.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HouseholdServices.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        private HouseholdServiceModel dbContext;

        #region Properties
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected HouseholdServiceModel DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }
        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(r => r.ID == id);
        }
    }
}
