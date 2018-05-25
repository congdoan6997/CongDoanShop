using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongDoan.Data.Infacstructure
{
    public interface IDbFactory:IDisposable
    {
        CongDoanShopDbContext Init();
    }
}
