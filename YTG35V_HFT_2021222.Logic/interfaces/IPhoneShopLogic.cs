﻿using System.Collections.Generic;
using System.Linq;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Logic
{
    public interface IPhoneShopLogic
    {
        public IEnumerable<EmployeesToShops> EmployeesToShopss(IEmployeesLogic logic);
        public EmployeesToShops Bestshop(IEmployeesLogic logic);
        void Create(Phoneshop item);
        void Delete(int id);
        Phoneshop Read(int id);
        IQueryable<Phoneshop> ReadAll();
        void Update(Phoneshop item);
    }
}