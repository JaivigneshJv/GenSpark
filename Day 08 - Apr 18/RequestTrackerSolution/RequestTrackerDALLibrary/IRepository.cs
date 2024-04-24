using System.Collections.Generic;

namespace RequestTrackerDALLibrary
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity? GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Delete(TKey id);
    }
}
