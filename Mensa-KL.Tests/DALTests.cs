﻿using Mensa_KL.DAL;
using Mensa_KL.Models;
using Microsoft.Data.Entity;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Tests
{
    [TestFixture]
    public class DALTests
    {
        Mock<DbSet<Meal>> mock_DbSet_Meals;
        Mock<MensaDbContext> mock_MensaDbContext;

        [SetUp]
        public void Setup()
        {
            var meal1 = new Meal { MealId = 1, Date = new DateTime(2015, 1, 1), Location = Location.MENSA_1, Title = "Schmorbraten" };
            var meal2 = new Meal { MealId = 2, Date = new DateTime(2015, 1, 2), Location = Location.MENSA_2, Title = "Blunzegrötschl" };
            var meals = new List<Meal> { meal1, meal2 }.AsQueryable();

            mock_DbSet_Meals = new Mock<DbSet<Meal>>().Initialize(meals);

            mock_MensaDbContext = new Mock<MensaDbContext>();
            mock_MensaDbContext.Setup(x => x.MealSet).Returns(mock_DbSet_Meals.Object);
        }

        [Test]
        public void GetMealsBetweenTwoDates()
        {
            var mealDataManager = new MealDataManager(mock_MensaDbContext.Object);
            var meals = mealDataManager.GetMeals(start: new DateTime(2015, 1, 1),
                                                   end: new DateTime(2015, 1, 2));

            Assert.That(meals, Has.Member(new Meal { MealId = 1 }));
            Assert.That(meals, Has.Member(new Meal { MealId = 2 }));
        }
    }
}