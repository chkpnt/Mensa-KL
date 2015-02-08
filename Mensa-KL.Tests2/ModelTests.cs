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

        }

        [Test]
        public void TestSortierreihenfolge_Locations()
        {
            var locations = new List<Location>
            {
                Location.GRILL,
                Location.MENSA_1,
                Location.WOK
            };

            Assert.That(locations, Is.Ordered);
        }
    }
}
