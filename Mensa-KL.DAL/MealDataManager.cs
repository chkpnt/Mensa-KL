using Mensa_KL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.DAL
{
    public class MealDataManager : DataManagerBase
    {
        public MealDataManager() : this(null) { }

        internal MealDataManager(MensaDbContext ctx = null)
        {
            Init(ctx);
        }

        public List<Meal> GetMeals(DateTime start, DateTime end)
        {
            var query = from meal in ctx.MealSet
                        where start <= meal.Date && meal.Date <= end
                        orderby meal
                        select meal;

            return query.ToList();
        }
    }
}
