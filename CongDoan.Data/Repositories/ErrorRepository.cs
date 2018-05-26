using CongDoan.Data.Infacstructure;
using CongDoan.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongDoan.Data.Repositories
{
    public interface IErrorRepository:IRepository<Error>
    {

    }
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
