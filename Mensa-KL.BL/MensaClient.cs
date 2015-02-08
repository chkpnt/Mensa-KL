using Mensa_KL.DAL;
using Mensa_KL.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mensa_KL.BL
{
    public class MensaClient
    {
        private readonly ISyncClient _syncClient;
        private readonly MealDataManager _mealDataManager; 

        public MensaClient() : this(null) { }

        internal MensaClient(ISyncClient syncClient)
        {
            if (syncClient != null)
            {
                this._syncClient = syncClient;
            }
            else
            {
                this._syncClient = new MensaKLSyncClient();
            }
        }

        public void UpdateMeals(DateTime start, DateTime end)
        {
            _syncClient.FetchMeals(start, end);
        }
    }
}
