using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTG35V_HFT_2021222.Models.classes
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey(nameof(Phoneshop))]
        public int EmployeesId { get; set; }

        [Required]
        [StringLength(240)]
        public string EmployeeName { get; set; }

        [ForeignKey(nameof(Phoneshop))]
        public int PhoneshopId { get; set; }
        public DateTime HireDate { get; set; }
        public double EmployeeRating { get; set; }

        public virtual Phoneshop Phoneshops { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
        public Employee()
        {
            
        }
        public Employee(string line)
        {
            string[] split = line.Split('*');
        }

    }
}
