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
    public class LocationTests
    {
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
