using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTG35V_HFT_2021222.Models.classes
{
    public class Phones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public string Phoneid { get; set; }

        [StringLength(240)]
        public string Brand { get; set; }

        [ForeignKey(nameof(Employee))]
        public int PhonesModelid { get; set; }

        [StringLength(240)]
        public string PhonesModel { get; set; }
        public double PhonesRating { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Phoneshop>  Phoneshops { get; set; }
        public Phones()
        {

        }
        public Phones(string line)
        {
            string[] split = line.Split('*');
        }

    }
}
