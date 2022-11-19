using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YTG35V_HFT_2021222.Models.classes
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(240)]
        public string EmployeeName { get; set; }

        [ForeignKey(nameof(Phoneshop))]
        public int PhoneshopId { get; set; }
       
        public double EmployeeRating { get; set; }

        public virtual Phoneshop Phoneshops { get; set; }
        [JsonIgnore]
        public virtual ICollection<Phones> Phones { get; set; }
        public Employee()
        {
            
        }
        public Employee(string line)
        {
            string[] split = line.Split('#');
            EmployeeId = int.Parse(split[0]);
            EmployeeName = split[1];
            PhoneshopId = int.Parse(split[2]);
            EmployeeRating = int.Parse(split[3]);
        }

    }
}
