using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Sync
{
    public class MensaKLSyncClient : ISyncClient
    {
        public string APIUrl { get; set; }

        public MensaKLSyncClient()
        {
            APIUrl = "http://www.mensa-kl.de/?mode=mensaxml";
        }

        public Task<List<Models.Meal>> FetchMeals(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }


    }
}
