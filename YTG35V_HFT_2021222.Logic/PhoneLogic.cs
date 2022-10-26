﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTG35V_HFT_2021222.Models.classes;
using YTG35V_HFT_2021222.Repository;

namespace YTG35V_HFT_2021222.Logic
{
    class PhoneLogic : IPhoneLogic
    {
        IRepository<Phones> repo;

        public PhoneLogic(IRepository<Phones> repo)
        {
            this.repo = repo;
        }

        public void Create(Phones item)
        {
            if (item.Brand.Length < 3)
            {
                throw new ArgumentException("The shop name is too short");
            }
            this.repo.Create(item);

        }

        public void Delete(Phones id)
        {

            this.repo.Delete(id);
        }

        public Phones Read(int id)
        {
            var asd = this.repo.Read(id);
            if (asd == null)
            {
                throw new ArgumentException("The shop  not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Phones> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Phones item)
        {
            this.repo.Update(item);
        }
    }
}