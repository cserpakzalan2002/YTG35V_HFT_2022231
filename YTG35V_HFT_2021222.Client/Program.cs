﻿using ConsoleTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YTG35V_HFT_2021222.Models.classes;

namespace YTG35V_HFT_2021222.Client
{
    static class MyExtension
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"********** {header} **********");
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"********************************");
            Console.ReadLine();
        }
    }
    internal class Program
    {
        static RestService rest;

        static void EmployeesToShopss()
        {
            
            List<object> list = rest.Get<object>("/NonCrud/EmployeesToShopss");
            list.ToConsole("How many employees in every shop");
           
            
            
        }
        static void BestShop()
        {

            object list = rest.GetSingle<object>("/NonCrud/BestShop");
            Console.WriteLine($"The best shop {list}");
            Console.ReadLine();

        }
        static void EmployeesToPhoneCountWhatheysell()
        {
            List<object> list = rest.Get<object>("/NonCrud/EmployeesToPhoneCountWhatheysell");
            list.ToConsole("List of employees and their phone what they selling");
        }
        static void BestEmployee()
        {
            object list = rest.GetSingle<object>("/NonCrud/BestEmployee");
            Console.WriteLine($"The best Employee {list}" );
            Console.ReadLine();
        }
        static void avaragethePhonebyemployeeId()
        {
            Console.WriteLine("Enter an Employee Id: ");
            int id = int.Parse(Console.ReadLine());
            var avarage = rest.Get<object>(id, "/NonCrud/avaragethePhonebyemployeeId");
            Console.WriteLine("The avarage is: ");
            Console.WriteLine(avarage);
            
            Console.ReadLine();



        }
        static void Create(string entity)
        {
            if (entity == "Phoneshop")
            {
                Console.Write("Enter phoneshop Name: ");
                string name = Console.ReadLine();
                rest.Post(new Phoneshop() { ShopName = name }, "phoneshop");
            }
            if(entity == "Phones")
            {
                Console.Write("Enter phones Name: ");
                string name = Console.ReadLine();
                rest.Post(new Phones() { Brand = name }, "phones");
            }
            if (entity == "Employee")
            {
                Console.Write("Enter employee Name: ");
                string name = Console.ReadLine();
                rest.Post(new Employee() { EmployeeName = name }, "employee");
            }
        }
        static void List(string entity)
        {
            if (entity == "Phoneshop")
            {
                List<Phoneshop> shops = rest.Get<Phoneshop>("phoneshop");
                foreach (var item in shops)
                {
                    Console.WriteLine(item.PhoneshopId + ": " + item.ShopName);
                }
            }
            if(entity == "Phones")
            {
                List<Phones> shops = rest.Get<Phones>("phones");
                foreach (var item in shops)
                {
                    Console.WriteLine(item.Phoneid + ": " + item.Brand);
                }
            }
            if (entity == "Employee")
            {
                List<Employee> shops = rest.Get<Employee>("employee");
                foreach (var item in shops)
                {
                    Console.WriteLine(item.EmployeeId + ": " + item.EmployeeName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Phoneshop")
            {
                Console.Write("Enter phoneshopname's id to update: ");
                int id = int.Parse(Console.ReadLine());              
                Phoneshop one = rest.Get<Phoneshop>(id, "phoneshop");
                Phoneshop vmi = new Phoneshop()
                {
                    PhoneshopId = one.PhoneshopId,
                };
                Console.Write($"New name [old: {one.ShopName}]: ");
                string name = Console.ReadLine();              
                vmi.ShopName = name;
                rest.Put(vmi, "Phoneshop");
            }
            if(entity == "Phones")
            {
                Console.Write("Enter Phone's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Phones one = rest.Get<Phones>(id, "Phones");
                Phones vmi = new Phones()
                {
                    Phoneid = one.Phoneid,
                };
                Console.Write($"New name [old: {one.Brand}]: ");
                string name = Console.ReadLine();
                vmi.Brand = name;
                rest.Put(vmi, "Phones");
            }
            if (entity == "Employee")
            {
                Console.Write("Enter Employee's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Employee one = rest.Get<Employee>(id, "Employee");
                Employee vmi = new Employee()
                {
                    EmployeeId = one.EmployeeId,
                };
                Console.Write($"New name [old: {one.EmployeeName}]: ");
                string name = Console.ReadLine();
                vmi.EmployeeName = name;
                rest.Put(vmi, "Employee");
            }
            
        }
        static void Delete(string entity)
        {
            if (entity == "Phoneshop")
            {
                Console.Write("Enter phoneshop's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Phoneshop");
            }
            if(entity == "Phones")
            {
                Console.Write("Enter phone's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Phones");
            }
            if (entity == "Employee")
            {
                Console.Write("Enter Employee's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Employee");
            }
        }

        //phones 

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53910/", "phoneshop");

            var phoneshopSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Phoneshop"))
                .Add("Create", () => Create("Phoneshop"))
                .Add("Delete", () => Delete("Phoneshop"))
                .Add("Update", () => Update("Phoneshop"))
                .Add("Exit", ConsoleMenu.Close);

            var employeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);

            var phonesSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Phones"))
                .Add("Create", () => Create("Phones"))
                .Add("Delete", () => Delete("Phones"))
                .Add("Update", () => Update("Phones"))
                .Add("Exit", ConsoleMenu.Close);

            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("EmployeesToShopss", () => EmployeesToShopss())
                .Add("BestShop", () => BestShop())
                .Add("EmployeesToPhoneCountWhatheysell", () => EmployeesToPhoneCountWhatheysell())
                .Add("BestEmployee", () => BestEmployee())
                .Add("avaragethePhonebyemployeeId", () => avaragethePhonebyemployeeId())
                .Add("Exit", ConsoleMenu.Close);



            var menu = new ConsoleMenu(args, level: 0)
                .Add("Phoneshops", () => phoneshopSubMenu.Show())
                .Add("Employees", () => employeeSubMenu.Show())
                .Add("Phones", () => phonesSubMenu.Show())      
                .Add("Noncrud", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            ;


        }
    }
}
