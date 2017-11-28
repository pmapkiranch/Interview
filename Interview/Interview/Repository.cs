using System;
using System.Collections.Generic;

namespace Interview
{
    public class Repository<T> : IRepository<T> where T : Storable
    {
        private List<T> _items;

        public Repository()
        {
            _items = new List<T>();
        }
        public IEnumerable<T> All()
        {
            return _items;
        }

        public void Delete(IComparable id)
        {
            _items.RemoveAll(getIdPcate(id));
        }

        public T FindById(IComparable id)
        {
            return _items.Find(getIdPcate(id));
        }

        public void Save(T item)
        {
            if (!Equals(item, default(T)))
            {
                _items.RemoveAll(getIdPcate(item.Id));
                _items.Add(item);
            }
        }



        private Predicate<T> getIdPcate(IComparable id)
        {
            return (i => i.Id.Equals(id));
        }
    }
}