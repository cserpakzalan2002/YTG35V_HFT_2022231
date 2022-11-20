using System.Collections.Generic;
using System.Linq;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Logic
{
    public interface IPhoneLogic
    {
        public double getavgphone(int id);
        void Create(Phones item);
        void Delete(int id);
        Phones Read(int id);
        IQueryable<Phones> ReadAll();
        void Update(Phones item);
    }
}