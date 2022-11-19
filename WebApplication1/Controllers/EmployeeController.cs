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
    [Route("[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        IEmployeesLogic logic;
        public EmployeeController(IEmployeesLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Employee> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Employee Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Employee value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Employee value)
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
