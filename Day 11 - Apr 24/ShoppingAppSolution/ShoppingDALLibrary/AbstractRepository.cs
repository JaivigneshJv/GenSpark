﻿namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected IList<T> items = new List<T>();

        public T Add(T item)
        {
            items.Add(item);
            return item;
        }

        public ICollection<T> GetAll()
        {
            return items.ToList();
        }

        public abstract T Delete(K key);
        public abstract T GetByKey(K key);
        public abstract T Update(T item);
    }
}
