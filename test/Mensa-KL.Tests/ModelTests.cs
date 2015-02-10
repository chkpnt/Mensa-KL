using Mensa_KL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mensa_KL.Tests
{
    [TestFixture]
    public class ModelTests
    {
        [Test]
        public void TestSortierreihenfolge_Meals()
        {
            var meal_Day1_Mensa1 = new Meal { Date = new DateTime(2015, 1, 1), Location = Location.MENSA_1 };
            var meal_Day1_Wok = new Meal { Date = new DateTime(2015, 1, 1), Location = Location.WOK };
            var meal_Day2_Mensa2 = new Meal { Date = new DateTime(2015, 1, 2), Location = Location.MENSA_2 };
            var meal_Day2_Buffet = new Meal { Date = new DateTime(2015, 1, 2), Location = Location.BUFFET };
            
            var unsortedMeals1 = new List<Meal> { meal_Day1_Mensa1, meal_Day2_Buffet, meal_Day1_Wok, meal_Day2_Mensa2 };
            var unsortedMeals2 = new List<Meal> { meal_Day1_Mensa1, meal_Day1_Wok, meal_Day2_Buffet, meal_Day2_Mensa2 };
            var sortedMeals = new List<Meal> { meal_Day1_Mensa1, meal_Day1_Wok, meal_Day2_Mensa2, meal_Day2_Buffet };

            Assert.That(unsortedMeals1, Is.Not.Ordered);
            Assert.That(unsortedMeals2, Is.Not.Ordered);
            Assert.That(sortedMeals, Is.Ordered);
        }

        [Test]
        public void TestEqualityOfMeals()
        {
            var meal1 = new Meal { MealId = 1, Date = new DateTime(2015, 1, 1), Location = Location.MENSA_1 };
            var meal2 = new Meal { MealId = 2, Date = new DateTime(2015, 1, 1), Location = Location.MENSA_1 };
            var meal3 = new Meal { MealId = 1, Date = new DateTime(2015, 2, 2), Location = Location.WOK };

            Assert.That(meal1, Is.Not.EqualTo(meal2));
            Assert.That(meal1, Is.EqualTo(meal3));
        }

        [Test]
        public void TestSortOrderOfLocations()
        {
            var unorderedLocations = new List<Location>
            {
                Location.GRILL,
                Location.MENSA_1,
                Location.WOK
            };

            var orderedLocations = new List<Location>
            {
                Location.MENSA_1,
                Location.MENSA_2,
                Location.WOK,                
                Location.GRILL,
                Location.BUFFET,
                Location.UNIQUE
            };

            Assert.That(unorderedLocations, Is.Not.Ordered);
            Assert.That(orderedLocations, Is.Ordered);
        }
    }
}
