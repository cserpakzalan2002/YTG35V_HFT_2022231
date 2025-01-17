﻿using System;
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
            if (item.ShopName.Length < 1)
            {
                throw new ArgumentException("The shop name is too short");
            }

            this.repo.Create(item);


        }

        public void Delete(int id)
        {

            this.repo.Delete(id);
        }

        public Phoneshop Read(int id)
        {
            Phoneshop asd = this.repo.Read(id);
            if (asd == null)
            {
                throw new ArgumentException("The shop  not exist");
            }
            
            return asd;
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

       

        
       
       
      
        
        public IEnumerable<EmployeesToShops> EmployeesToShopss(IEmployeesLogic logic)
        {
            var q1 = from x in logic.ReadAll()
                     from y in repo.ReadAll()
                     where x.PhoneshopId == y.PhoneshopId
                     group y by y.ShopName into g
                     select new EmployeesToShops()
                     {
                         name = g.Key,
                         count = g.Count()
                     };
            return q1;
        }
        public EmployeesToShops Bestshop(IEmployeesLogic logic)
        {
            var q1 = from x in logic.ReadAll()
                     from y in repo.ReadAll()
                     where x.PhoneshopId == y.PhoneshopId
                     group y by y.ShopName into g
                     select new EmployeesToShops()
                     {
                         name = g.Key,
                         count = g.Count()
                     };

            var qseged = q1.Max(t => t.count);
            var q2 = q1.FirstOrDefault(t => t.count == qseged);
            return q2;
        }






    }


    public class EmployeesToShops
    {
        public string name { get; set; }
        public int count { get; set; }
        
    }
}
