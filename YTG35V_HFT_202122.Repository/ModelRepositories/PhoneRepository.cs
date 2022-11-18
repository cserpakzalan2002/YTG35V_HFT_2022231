using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTG35V_HFT_202122.Repository;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Repository
{

    public class PhoneRepository : Repository<Phones>, IRepository<Phones>
    {
        public PhoneRepository(PhoneDbContext ctx) : base(ctx)
        {
        }
        public override Phones Read(int id)
        {
            return ctx.Phones.FirstOrDefault(t => t.Phoneid == id);
        }

        public override void Update(Phones item)
        {
            var old = Read(item.Phoneid);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
