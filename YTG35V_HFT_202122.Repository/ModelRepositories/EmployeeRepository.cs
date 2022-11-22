using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTG35V_HFT_202122.Repository;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Repository
{
    public class EmployeeRepository : Repository<Employee> , IRepository<Employee>
    {

        public EmployeeRepository(PhoneDbContext ctx) : base(ctx)
        {
        }
        public override Employee Read(int id)
        {
            return ctx.employees.FirstOrDefault(t => t.EmployeeId == id);

        }

        public override void Update(Employee item)
        {
            var old = Read(item.EmployeeId);
            ;
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }

            }
            ctx.SaveChanges();
        }
    }
}
