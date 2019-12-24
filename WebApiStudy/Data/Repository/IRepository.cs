using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApiStudy.Data.Repository.EntityRepository.UserRepo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void SaveChanges();
    }
}
