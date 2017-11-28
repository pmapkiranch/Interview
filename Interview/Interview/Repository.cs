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
            throw new NotImplementedException();
        }

        public T FindById(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}