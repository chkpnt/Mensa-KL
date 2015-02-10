using Mensa_KL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Model.Tests
{
    [TestFixture]
    public class MealTests
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
    }
}
