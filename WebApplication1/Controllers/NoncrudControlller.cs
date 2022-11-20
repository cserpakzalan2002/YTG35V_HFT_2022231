using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YTG35V_HFT_2021222.Logic;
using YTG35V_HFT_2021222.Models.classes;
using System.Text.Json.Serialization;

namespace YTG35V_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class NoncrudController : ControllerBase
    {
        IEmployeesLogic logic;
        IPhoneShopLogic logic1;
        IPhoneLogic logic2;
        public NoncrudController(IEmployeesLogic logic, IPhoneShopLogic logic1, IPhoneLogic logic2)
        {
            this.logic = logic;
            this.logic1 = logic1;
            this.logic2 = logic2;
        }

        [HttpGet()]
        public IEnumerable<EmployeesToShops> EmployeesToShopss()
        {
            return this.logic1.EmployeesToShopss(logic);
        }
        [HttpGet()]
        public EmployeesToShops BestShop()
        {
            return this.logic1.Bestshop(logic);
        }

        [HttpGet()]
        public IEnumerable<GreatEmployee> EmployeesToPhoneCountWhatheysell()
        {
            return this.logic.greatEmployees(logic2);
        }
        [HttpGet()]
        public GreatEmployee BestEmployee()
        {
            return this.logic.BestEmployee(logic2);
        }


    }
}
