using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinemaNgApi.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        HomeCinemaNgApiDbContext dbContext;
        public HomeCinemaNgApiDbContext Init()
        {
            return dbContext ?? (dbContext = new HomeCinemaNgApiDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
