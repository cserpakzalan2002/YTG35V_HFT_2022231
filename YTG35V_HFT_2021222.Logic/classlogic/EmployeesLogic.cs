using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using YTG35V_HFT_2021222.Models.classes;
using YTG35V_HFT_2021222.Repository;

namespace YTG35V_HFT_2021222.Logic
{
    public class EmployeesLogic : IEmployeesLogic
    {
        IRepository<Employee> repo;

        public EmployeesLogic(IRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public void Create(Employee item)
        {
            if (item.EmployeeName.Length < 3)
            {
                throw new ArgumentException("The shop name is too short");
            }
            this.repo.Create(item);

        }

        public void Delete(int id)
        {

            this.repo.Delete(id);
        }

        public Employee Read(int id)
        {
            var asd = this.repo.Read(id);
            if (asd == null)
            {
                throw new ArgumentException("The shop  not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Employee> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Employee item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<GreatEmployee> greatEmployees(IPhoneLogic logic)
        {
            var q1 = from x in logic.ReadAll()
                     from y in repo.ReadAll()
                     where x.EmployeesId == y.EmployeeId
                     group y by y.EmployeeName into g
                     select new GreatEmployee()
                     {
                         szam = g.Key,
                         count = g.Count()
                     };
            return q1;
        }

    }

    public class GreatEmployee
    {
        public string szam { get; set; }
        public int count { get; set; }
    }
}
