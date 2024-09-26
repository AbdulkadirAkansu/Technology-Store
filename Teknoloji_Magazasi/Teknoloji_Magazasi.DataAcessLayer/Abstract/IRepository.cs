using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoloji_Magazasi.DataAcessLayer.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetItem(object key);
        void Add(T item);
        void Update(T item);
        void Remove(object key);
        void Remove(T item);
    }
}
