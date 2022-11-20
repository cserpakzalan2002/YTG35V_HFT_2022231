using Microsoft.EntityFrameworkCore;
using System;
using YTG35V_HFT_2021222.Models;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_202122.Repository
{
    public class PhoneDbContext : DbContext
    {
        public DbSet<Phones> Phones { get; set; }
        public DbSet<Phoneshop> Phoneshops { get; set; }
        public DbSet<Employee> employees { get; set; }


        public PhoneDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Datas.mdf;Integrated Security=True;MultipleActiveResultSets = true";
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("asd");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(Employee => Employee
                .HasOne(Employee => Employee.Phoneshops)
                .WithMany(shop => shop.Employees)
                .HasForeignKey(employeesid => employeesid.PhoneshopId)
                .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Phones>(Phones => Phones
               .HasOne(e => e.Employees)
               .WithMany(r => r.Phones)
               .HasForeignKey(Phones => Phones.EmployeesId)
               .OnDelete(DeleteBehavior.Cascade));



            

            modelBuilder.Entity<Phoneshop>().HasData(new Phoneshop[]
            {
                new Phoneshop("1#Phoneshop xyz#5000#5"),
                new Phoneshop("2#Phoneshop yxz#2000#4"),
                new Phoneshop("3#Phoneshop zyx#1500#3"),
                new Phoneshop("4#Phoneshop axyz#1700#3"),
                
            });

            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                   new Employee("1#Jon Favreau#1#5"),
                new Employee("2#Louis Leterrier#1#5"),
                new Employee("3#Kenneth Branagh#1#4"),
                new Employee("4#Joe Johnston#1#2"),
                new Employee("5#Joss Whedon#2#3"),
                new Employee("6#Shane Black#2#3"),
                new Employee("7#Alan Taylor#3#5"),
                new Employee("8#Anthony and Joe Russo#3#4"),
                new Employee("9#James Gunn#3#4"),
                new Employee("10#Peyton Reed#4#2"),
                new Employee("11#Scott Derrickson#4#4"),
                new Employee("12#Jon Watts#4#5"),
               
            });

            modelBuilder.Entity<Phones>().HasData(new Phones[]
            {
                new Phones("1#Iphone 4#1#3"),
                new Phones("2#Iphone 4s#2#2"),
                new Phones("3#Iphone 5#3#4"),
                new Phones("4#Iphone 5c#4#2"),
                new Phones("5#Iphone 5s#5#5"),
                new Phones("6#Iphone 6#6#4"),
                new Phones("7#Iphone 6s#7#5"),
                new Phones("8#Iphone 6 Plus#8#4"),
                new Phones("9#Iphone 6 Plus s#9#3"),
                new Phones("10#Iphone 7#10#4"),
                new Phones("11#Iphone 7 Plus#11#5"),
                new Phones("12#Iphone 8#12#3"),
                new Phones("13#Iphone 8 Plus#1#5"),
                new Phones("14#Iphone X#2#1"),
                new Phones("15#Iphone XR#3#2"),
                new Phones("16#Iphone XS#4#5"),
                new Phones("17#Iphone 11#5#5"),
                new Phones("18#Iphone 11 Pro#6#5"),
                new Phones("19#Iphone 11 Pro Max#7#1"),
                new Phones("20#Iphone 12#8#3"),
                new Phones("21#Iphone 12 Pro#9#2"),
                new Phones("22#Iphone 12 Pro Max#10#1"),
                new Phones("23#Iphone 13#11#3"),
                new Phones("24#Iphone 13 Pro#12#1"),
                new Phones("25#Iphone 13 Pro Max#1#4"),
                new Phones("26#Iphone 14#1#1"),
                new Phones("27#Iphone 14 Pro#3#3"),
                new Phones("28#Iphone 14 Pro Max#4#2"),
               



            });

           
        }
    }
}
