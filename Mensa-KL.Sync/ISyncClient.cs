using Mensa_KL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Sync
{
    public interface ISyncClient
    {
        Task<List<Meal>> FetchMeals(DateTime start, DateTime end);
    }
}
