using System.Collections.Generic;
using System.Linq;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Logic
{
    public interface IEmployeesLogic
    {
        public IEnumerable<GreatEmployee> greatEmployees(IPhoneLogic logic);
        public GreatEmployee BestEmployee(IPhoneLogic logic);
        void Create(Employee item);
        void Delete(int id);
        Employee Read(int id);
        IQueryable<Employee> ReadAll();
        void Update(Employee item);
    }
}