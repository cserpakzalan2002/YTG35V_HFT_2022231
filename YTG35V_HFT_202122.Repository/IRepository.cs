using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTG35V_HFT_2021222.Repository
{
    public interface IRepository<T> where T :class
     {
        IQueryable<T> ReadAll();

        T Read(int id);

        void Create(T item);
        void Delete(T id);
        void Update(T item);
    }
}
