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
        Mock<IRepository<Phoneshop>> mockPhoneshopRepo;

        [SetUp]
        public void Init()
        {
            mockPhoneshopRepo = new Mock<IRepository<Phoneshop>>();
            mockPhoneshopRepo.Setup(m => m.ReadAll()).Returns(new List<Phoneshop>()
            {
                new Phoneshop("1#vmi#1#5"),
                new Phoneshop("2#vmi2#2#3"),
                new Phoneshop("3#vmi3#3#2"),
                new Phoneshop("4#vmi4#4#1"),
               
            }.AsQueryable());
            logic = new PhoneShopLogic(mockPhoneshopRepo.Object);
        }

        [Test]
        public void AvgRatePerYearTest()
        {
            double? avg = logic.GetAverageRatePerYear(2009);
            Assert.That(avg, Is.EqualTo(6.5));
        }

        [Test]
        public void YearStatisticsTest()
        {
            var actual = logic.YearStatistics().ToList();
            var expected = new List<YearInfo>()
            {
                new YearInfo()
                {
                    Year = 2008,
                    AvgRating = 5,
                    MovieNumber = 1
                },
                new YearInfo()
                {
                    Year = 2009,
                    AvgRating = 6.5,
                    MovieNumber = 2
                },
                new YearInfo()
                {
                    Year = 2010,
                    AvgRating = 8,
                    MovieNumber = 1
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateMovieTestWithCorrectTitle()
        {
            var movie = new Movie() { Title = "Vukk" };

            //ACT
            logic.Create(movie);

            //ASSERT
            mockMovieRepo.Verify(r => r.Create(movie), Times.Once);
        }

        [Test]
        public void CreateMovieTestWithInCorrectTitle()
        {
            var movie = new Movie() { Title = "24" };
            try
            {
                //ACT
                logic.Create(movie);
            }
            catch
            {

            }

            //ASSERT
            mockMovieRepo.Verify(r => r.Create(movie), Times.Never);
        }
    }
}
