using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongDoan.Data.Infacstructure
{
    public class DbFactory : Disposable,IDbFactory
    {

       private  CongDoanShopDbContext dbContext;

        public CongDoanShopDbContext Init()
        {
            return dbContext ?? (dbContext = new CongDoanShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
