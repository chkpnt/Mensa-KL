using Mensa_KL.BL;
using Mensa_KL.Models;
using Mensa_KL.Sync;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Tests
{
    [TestFixture]
    public class BLTests
    {
        [Test]
        public void TestUpdateMeals()
        {
            var syncClient = Substitute.For<ISyncClient>();

            var dateStart = new DateTime(2015,1,1);
            var dateEnd = new DateTime(2015,1,2);

            var meal1 = new Meal { MealId = 1, Date = new DateTime(2015, 1, 1), Location = Location.MENSA_1, Title = "Schmorbraten" };
            var meal2 = new Meal { MealId = 2, Date = new DateTime(2015, 1, 2), Location = Location.MENSA_2, Title = "Blunzegrötschl" };
            var meals = new List<Meal> { meal1, meal2 };

            syncClient.FetchMeals(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(Task.FromResult(meals));

            var mensaClient = new MensaClient(syncClient);
            mensaClient.UpdateMeals(dateStart, dateEnd);

            syncClient.Received().FetchMeals(Arg.Any<DateTime>(), Arg.Any<DateTime>());
        }
    }
}
