using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mensa_KL.Sync.Tests
{
    [TestFixture]
    public class XmlDeserializationTests
    {
        private XmlSerializer _deserializer;

        private Mensa _mensa;

        [SetUp]
        public void Setup()
        {
            _deserializer = new XmlSerializer(typeof(Mensa));
            Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList().ForEach(l => Console.WriteLine(l));
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Mensa_KL.Sync.Tests.Resources.meals.xml"))
            {
                _mensa = _deserializer.Deserialize(stream) as Mensa;
            }
        }

        [Test]
        public void testDemoXml()
        {
            Assert.That(_mensa.Days, Has.Count.EqualTo(3));
            Assert.That(_mensa.Days.First().Date, Is.EqualTo(new DateTime(2015, 3, 4)));
            Assert.That(_mensa.Days.First().Meals.First().MealId, Is.EqualTo(33070));
            Assert.That(_mensa.Days.First().Meals.First().Price, Is.EqualTo(2.15));
            Assert.That(_mensa.Days.First().Meals.First().Location.Name, Is.EqualTo("Ausgabe 2"));
            Assert.That(_mensa.Days.First().Meals.First().Title.Text, Is.EqualTo("Pfälzer Fleischküchle (Gl,Ei,Sf,S) mit Bratensoße (Gl,Sf), Grumbeer-Stampes (5,La,Sw) und Salat"));
        }

    }
}
