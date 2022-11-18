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

        public double EmployeesRating(string number)
        {
            return this.repo.ReadAll()
                .Where(t => t.EmployeeName == number)
                .Average(t => t.EmployeeRating);

        }
        public double GetAVgEmployees(int id)
        {
            return this.repo.Read(id).Phones
                .Average(t => t.Phoneid);
        }
        


    }
}
