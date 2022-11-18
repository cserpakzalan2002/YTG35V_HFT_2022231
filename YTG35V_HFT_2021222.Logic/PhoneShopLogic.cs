using System;
using YTG35V_HFT_2021222.Repository;
using YTG35V_HFT_2021222.Models;
using YTG35V_HFT_2021222.Models.classes;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace YTG35V_HFT_2021222.Logic
{
    public class PhoneShopLogic : IPhoneShopLogic
    {
        IRepository<Phoneshop> repo;

        public PhoneShopLogic(IRepository<Phoneshop> repo)
        {
            this.repo = repo;
        }

        public void Create(Phoneshop item)
        {
            if (item.ShopName.Length < 3)
            {
                throw new ArgumentException("The shop name is too short");
            }

            this.repo.Create(item);


        }

        public void Delete(Phoneshop id)
        {

            this.repo.Delete(id);
        }

        public Phoneshop Read(int id)
        {
            var asd = this.repo.Read(id);
            if (asd == null)
            {
                throw new ArgumentException("The shop  not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Phoneshop> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Phoneshop item)
        {
            this.repo.Update(item);
        }

        //non cruds

        public double AvaragePhoneshop(string number)
        {
            return this.repo.ReadAll()
                .Where(t => t.ShopName == number)
                .Average(t => t.Rating);

        }

        public IEnumerable<Employee> Workers(int vmi)
        {
            return this.repo.Read(vmi).Employees;
                
        }
        public double GetAVgphoneshoplogic(int id)
        {
            return this.repo.Read(id).Employees
                .Average(t => t.EmployeesId);
        }
        public double GetmaxratingEmployees(int id)
        {
            return this.repo.Read(id).Phones
                .Max(t=>t.PhonesRating);
        }
    }
}
