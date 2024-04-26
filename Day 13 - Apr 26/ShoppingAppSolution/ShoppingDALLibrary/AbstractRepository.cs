namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected IList<T> items = new List<T>();

        public virtual Task<T> Add(T item)
        {
            items.Add(item);
            return Task.FromResult(item);
        }

        public virtual Task<ICollection<T>> GetAll()
        {
            return Task.FromResult((ICollection<T>)items);
        }

        public abstract Task<T> Delete(K key);

        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);
    }
}
