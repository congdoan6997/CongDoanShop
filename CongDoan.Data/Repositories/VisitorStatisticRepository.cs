using CongDoan.Data.Infacstructure;
using CongDoan.Model.Models;

namespace CongDoan.Data.Repositories
{
    public interface IVisitirStatisticRepository : IRepository<VisitorStatistic>
    {
    }
    

    public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, IVisitirStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}