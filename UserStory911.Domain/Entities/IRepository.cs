using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UserStory911.Domain.Entities
{
    /// <summary>
    /// The repository interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Create.
        /// </summary>
        /// <returns></returns>
        TEntity Create();

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Finds the specified where expression.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);
    }
}
