using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserStory911.Domain.Entities;

namespace UserStory911.Domain.Repository
{
    public class FakeRepositoryBase<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Holds the fake repository data
        /// </summary>
        protected readonly HashSet<T> data;

        public FakeRepositoryBase()
        {
            this.data = new HashSet<T>();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public virtual void Add(T entity)
        {
            this.data.Add(entity);
        }

        public void Remove(T entity)
        {
            this.data.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> @where)
        {
            return this.data.Where(where.Compile());
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void PopulateData(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Add(entity);
            }
        }
    }
}
