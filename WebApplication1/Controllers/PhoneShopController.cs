using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YTG35V_HFT_2021222.Logic;
using YTG35V_HFT_2021222.Models.classes;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneShopController : ControllerBase
    {
        IPhoneShopLogic logic;
        public PhoneShopController(IPhoneShopLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Phoneshop> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Phoneshop Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Phoneshop value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Phoneshop value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
