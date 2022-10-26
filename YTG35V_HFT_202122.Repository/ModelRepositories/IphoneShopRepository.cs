using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTG35V_HFT_202122.Repository;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Repository
{
    public class IphoneShopRepository : Repository<Phoneshop>, IRepository<Phoneshop>
    {
        public IphoneShopRepository(PhoneDbContext ctx) : base(ctx)
        {
        }

       

       

        public override Phoneshop Read(int id)
        {
            return ctx.Phoneshops.FirstOrDefault(t => t.PhoneshopId == id);
        }

      

        public override void Update(Phoneshop item)
        {
            var old = Read(item.PhoneshopId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
