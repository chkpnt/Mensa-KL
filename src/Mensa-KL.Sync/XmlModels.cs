using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mensa_KL.Sync
{
    [XmlRoot("mensa")]
    public class Mensa
    {
        [XmlElement("day")]
        public List<MensaDay> Days { get; set; }
    }


    public class MensaDay
    {
        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlElement("meal")]
        public List<MensaMeal> Meals { get; set; }
    }

    public class MensaMeal
    {
        [XmlAttribute("m_id")]
        public int MealId { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlElement("loc")]
        public MensaLocation Location { get; set; }

        [XmlElement("title")]
        public MensaMealTitle Title { get; set; }

        [XmlElement("mimg")]
        public MensaMealImage Image { get; set; }

        [XmlElement("rating")]
        public MensaMealRating Rating { get; set; }
    }

    public class MensaLocation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("collection")]
        public bool IsCollection { get; set; }

        [XmlText]
        public string NameText { get; set; }

    }

    public class MensaMealTitle
    {
        [XmlAttribute("icon")]
        public string Icon { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    public class MensaMealImage
    {
        [XmlAttribute("accuracy")]
        public int Accuracy { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlText]
        public string Filename { get; set; }
    }

    public class MensaMealRating
    {
        [XmlText]
        public decimal Value { get; set; }

        [XmlAttribute("amt")]
        public int Amount { get; set; }
    }

}
