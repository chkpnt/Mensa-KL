using Mensa_KL.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
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

        internal List<Meal> GetMeals()
        {
            return ctx.MealSet.ToList();
        }

        public List<Meal> GetMeals(DateTime start, DateTime end)
        {
            var query = from meal in ctx.MealSet
                        where start <= meal.Date && meal.Date <= end
                        orderby meal
                        select meal;

            return query.ToList();
        }

        public void SaveMeals(List<Meal> meals)
        {
            var newMeals = from meal in meals
                           where !ctx.MealSet.Any(m => m.MealId == meal.MealId)
                           select meal;

            var updatedMeals = meals.Except(newMeals);

            ctx.MealSet.AddRange(newMeals);
            ctx.MealSet.UpdateRange(updatedMeals);

            ctx.SaveChanges();
        }
    }
}
