using CongDoan.Data.Infacstructure;
using CongDoan.Model.Models;

namespace CongDoan.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {
    }

    internal class FooterRepository : RepositoryBase<Footer>, IRepository<Footer>
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}