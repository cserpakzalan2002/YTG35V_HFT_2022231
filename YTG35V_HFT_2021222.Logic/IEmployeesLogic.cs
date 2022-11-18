using System.Linq;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Logic
{
    interface IEmployeesLogic
    {
        public double EmployeesRating(string number);
        void Create(Employee item);
        void Delete(Employee id);
        Employee Read(int id);
        IQueryable<Employee> ReadAll();
        void Update(Employee item);
    }
}