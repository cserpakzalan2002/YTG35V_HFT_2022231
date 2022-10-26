using System.Linq;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Logic
{
    interface IPhoneLogic
    {
        void Create(Phones item);
        void Delete(Phones id);
        Phones Read(int id);
        IQueryable<Phones> ReadAll();
        void Update(Phones item);
    }
}