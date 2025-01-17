﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YTG35V_HFT_2021222.Models.classes
{
     public class Phoneshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneshopId { get; set; }

        [Required]
        [StringLength(240)]
        public string ShopName { get; set; }

        [Range(0, 10000)]
        public double Income { get; set; }
 

        [Range(0, 10)]
        public double Rating { get; set; }



        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        [JsonIgnore]
        public virtual ICollection<Phones> Phones { get; set; }

        public Phoneshop()
        {
            
        }

        public Phoneshop(string line)
        {
            string[] split = line.Split('#');
            PhoneshopId = int.Parse(split[0]);
            ShopName = split[1];
            Income = int.Parse(split[2]);
            Rating = int.Parse(split[3]);
        }
    }
}
