using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using YTG35V_HFT_2021222.Logic;
using YTG35V_HFT_2021222.Models.classes;
using YTG35V_HFT_2021222.Repository;

namespace YTG35V_HFT_2021222_Test
{
    [TestFixture]
    public class Tester
    {
        PhoneShopLogic logic;
        PhoneLogic logic2;
        EmployeesLogic logic3;
        Mock<IRepository<Phoneshop>> mockPhoneshopRepo;
        Mock<IRepository<Phones>> phones;
        Mock<IRepository<Employee>> employee;

        [SetUp]
        public void Init()
        {
            mockPhoneshopRepo = new Mock<IRepository<Phoneshop>>();
            mockPhoneshopRepo.Setup(m => m.ReadAll()).Returns(new List<Phoneshop>()
            {
               new Phoneshop("1#Phoneshop xyz#5000#5"),
                new Phoneshop("2#Phoneshop yxz#2000#4"),
                new Phoneshop("3#Phoneshop zyx#1500#3"),
                new Phoneshop("4#Phoneshop axyz#1700#3"),

            }.AsQueryable());
            logic = new PhoneShopLogic(mockPhoneshopRepo.Object);

            phones = new Mock<IRepository<Phones>>();
            phones.Setup(m => m.ReadAll()).Returns(new List<Phones>()
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
            }.AsQueryable());
            logic2 = new PhoneLogic(phones.Object);

            
            employee = new Mock<IRepository<Employee>>();
            employee.Setup(m => m.ReadAll()).Returns(new List<Employee>()
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
            }.AsQueryable());
            logic3 = new EmployeesLogic(employee.Object);

        }

     

        [Test]
        public void EmployeesToShopss()
        {
            List<EmployeesToShops> vmi =new List<EmployeesToShops>()
            {
                new EmployeesToShops(){ name = "Phoneshop xyz" , count = 4},
                new EmployeesToShops(){ name = "Phoneshop yxz" , count = 2},
                new EmployeesToShops(){ name = "Phoneshop zyx" , count = 3},
                new EmployeesToShops(){ name = "Phoneshop axyz" , count = 3},

            };

            //employees
            Mock<IRepository<Employee>> mockEmployeehopRepo;

            mockEmployeehopRepo = new Mock<IRepository<Employee>>();
            mockEmployeehopRepo.Setup(m => m.ReadAll()).Returns(new List<Employee>()
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

            }.AsQueryable());
            logic3 = new EmployeesLogic(mockEmployeehopRepo.Object);

            //shops
            mockPhoneshopRepo = new Mock<IRepository<Phoneshop>>();
            mockPhoneshopRepo.Setup(m => m.ReadAll()).Returns(new List<Phoneshop>()
            {
                 new Phoneshop("1#Phoneshop xyz#5000#5"),
                new Phoneshop("2#Phoneshop yxz#2000#4"),
                new Phoneshop("3#Phoneshop zyx#1500#3"),
                new Phoneshop("4#Phoneshop axyz#1700#3"),

            }.AsQueryable());
            logic = new PhoneShopLogic(mockPhoneshopRepo.Object);


           

            var q1 = from x in logic3.ReadAll()
                     from y in logic.ReadAll()
                     where x.PhoneshopId == y.PhoneshopId
                     group y by y.ShopName into g
                     select new EmployeesToShops()
                     {
                         name = g.Key,
                         count = g.Count()
                     };

            foreach (var item in vmi)
            {
                foreach (var prop in q1)
                {
                    if(prop.name == item.name && prop.count == item.count)
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail(); 
                    }
                }
            }
                

           

        }
        [Test]
        public void greatEmployees()
        {
            List<GreatEmployee> vmi = new List<GreatEmployee>()
            {
                new GreatEmployee(){ name = "Phoneshop xyz" , count = 4},
                new GreatEmployee(){ name = "Phoneshop yxz" , count = 2},
                new GreatEmployee(){ name = "Phoneshop zyx" , count = 3},
                new GreatEmployee(){ name = "Phoneshop axyz" , count = 3},

            };

            //employees
            Mock<IRepository<Employee>> mockEmployeehopRepo;

            mockEmployeehopRepo = new Mock<IRepository<Employee>>();
            mockEmployeehopRepo.Setup(m => m.ReadAll()).Returns(new List<Employee>()
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

            }.AsQueryable());
            logic3 = new EmployeesLogic(mockEmployeehopRepo.Object);

            //shops
            mockPhoneshopRepo = new Mock<IRepository<Phoneshop>>();
            mockPhoneshopRepo.Setup(m => m.ReadAll()).Returns(new List<Phoneshop>()
            {
                 new Phoneshop("1#Phoneshop xyz#5000#5"),
                new Phoneshop("2#Phoneshop yxz#2000#4"),
                new Phoneshop("3#Phoneshop zyx#1500#3"),
                new Phoneshop("4#Phoneshop axyz#1700#3"),

            }.AsQueryable());
            logic = new PhoneShopLogic(mockPhoneshopRepo.Object);




            var q1 = from x in logic3.ReadAll()
                     from y in logic.ReadAll()
                     where x.PhoneshopId == y.PhoneshopId
                     group y by y.ShopName into g
                     select new GreatEmployee()
                     {
                         name = g.Key,
                         count = g.Count()
                     };

            foreach (var item in vmi)
            {
                foreach (var prop in q1)
                {
                    if (prop.name == item.name && prop.count == item.count)
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }




        }


        [Test]
        public void Bestshop()
        {
            

            //employees
            Mock<IRepository<Employee>> mockEmployeehopRepo;

            mockEmployeehopRepo = new Mock<IRepository<Employee>>();
            mockEmployeehopRepo.Setup(m => m.ReadAll()).Returns(new List<Employee>()
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

            }.AsQueryable());
            logic3 = new EmployeesLogic(mockEmployeehopRepo.Object);

            //shops
            mockPhoneshopRepo = new Mock<IRepository<Phoneshop>>();
            mockPhoneshopRepo.Setup(m => m.ReadAll()).Returns(new List<Phoneshop>()
            {
                 new Phoneshop("1#Phoneshop xyz#5000#5"),
                new Phoneshop("2#Phoneshop yxz#2000#4"),
                new Phoneshop("3#Phoneshop zyx#1500#3"),
                new Phoneshop("4#Phoneshop axyz#1700#3"),

            }.AsQueryable());
            logic = new PhoneShopLogic(mockPhoneshopRepo.Object);
        

       

            var q1 = from x in logic3.ReadAll()
                     from y in logic.ReadAll()
                     where x.PhoneshopId == y.PhoneshopId
                     group y by y.ShopName into g
                     select new EmployeesToShops()
                     {
                         name = g.Key,
                         count = g.Count()
                     };

            var qseged = q1.Max(t => t.count);
            var q2 = q1.FirstOrDefault(t => t.count == qseged);
            if(q2.count == 4)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
            
            

        }

        [Test]
        public void BestEmployee()
        {


            //employees
            Mock<IRepository<Employee>> mockEmployeehopRepo;

            mockEmployeehopRepo = new Mock<IRepository<Employee>>();
            mockEmployeehopRepo.Setup(m => m.ReadAll()).Returns(new List<Employee>()
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

            }.AsQueryable());
            logic3 = new EmployeesLogic(mockEmployeehopRepo.Object);

            //phones
            Mock<IRepository<Phones>> phones;

            phones = new Mock<IRepository<Phones>>();
            phones.Setup(m => m.ReadAll()).Returns(new List<Phones>()
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

            }.AsQueryable());
            logic2 = new PhoneLogic(phones.Object);




            var q1 = from x in logic2.ReadAll()
                     from y in logic3.ReadAll()
                     where x.EmployeesId == y.EmployeeId
                     group y by y.EmployeeName into g
                     select new GreatEmployee()
                     {
                         name = g.Key,
                         count = g.Count()
                     };

            var qseged = q1.Max(t => t.count);
            var q2 = q1.FirstOrDefault(t => t.count == qseged);
            if (q2.count == 4)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }



        }

      [Test]
      public void Phoneshopdelete()
        {
            //arrange
            logic.Delete(1);

            mockPhoneshopRepo.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
       public void Phonedelete()
        {
            //arrange
            logic2.Delete(1);

            phones.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void CreatePhoneTester()
        {
            Phones movie = new Phones() { Brand = "valami" };
            
            try
            {
                logic2.Create(movie);
            }
            catch
            {

            };
            phones.Verify(r => r.Create(movie), Times.Once);

        }

        [Test]
        [TestCase(1, 3.25)]
        public void getavgphone(int id, double excetion)
        {
            var value = logic2.getavgphone(id);
            Assert.That(excetion, Is.EqualTo(value));
        }

            [Test]
        public void CreatePhoneShopTester()
        {
            Phoneshop movie = new Phoneshop() { ShopName = "proba" };
            try
            {
                logic.Create(movie);
            }
            catch 
            {

            };
            mockPhoneshopRepo.Verify(r => r.Create(movie), Times.Once);

            //ASSERT

        }
        [Test]
        public void CreateEmployeeTester()
        {
            Employee movie = new Employee() { EmployeeName = "valami" };
            try
            {
                logic3.Create(movie);
            }
            catch
            {

            };
            employee.Verify(r => r.Create(movie), Times.Once);

            //ASSERT

        }
    }
}
