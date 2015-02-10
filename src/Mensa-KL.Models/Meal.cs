using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mensa_KL.Models
{
    public class Meal : IComparable<Meal>
    {
        public int MealId { get; set; }

        public DateTime Date { get; set; }

        public Location Location { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }

        public MealImage Image { get; set; }

        public int CompareTo(Meal other)
        {
            var dateComparison =  this.Date.CompareTo(other.Date);
            if (dateComparison != 0)
            {
                return dateComparison;
            }

            return this.Location.CompareTo(other.Location);
        }

        public bool Equals(Meal other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return int.Equals(other.MealId, MealId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Meal)) return false;
            return Equals((Meal)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return MealId.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Meal #{0} [Date={1}, Location={2}, Price={3}, Title={4}]", MealId, Date, Location, Price, Title);
        }
    }
}
