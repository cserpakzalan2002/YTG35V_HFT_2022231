using System;
using YTG35V_HFT_202122.Repository;
using YTG35V_HFT_2021222.Repository;

namespace YTG35V_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new PhoneDbContext();

            var IphoneshopREPo = new IphoneShopRepository(ctx);
            var employeeREPo = new EmployeeRepository(ctx);
            var phoneREPo = new PhoneRepository(ctx);


            var IphoneshopLogic = new PhoneLogic(phoneREPo);
        }
    }
}
