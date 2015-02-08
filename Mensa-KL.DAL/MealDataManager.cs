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
    }
}
