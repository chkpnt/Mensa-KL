using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.DAL
{
        public class DataManagerBase : IDisposable
        {
            protected MensaDbContext ctx;

            protected bool disposeContext = true;

            protected void Init(MensaDbContext ctx = null)
            {
                if (ctx != null)
                {
                    this.ctx = ctx;
                    this.disposeContext = false;
                }
                else
                {
                    this.ctx = new MensaDbContext();
                }
            }

            public void Dispose()
            {
                // Dispose() darf nur aufgerufen werden, falls swe Kontext nicht von außen hineingereicht wurde.
                if (disposeContext) ctx.Dispose();
            }
        }

}
