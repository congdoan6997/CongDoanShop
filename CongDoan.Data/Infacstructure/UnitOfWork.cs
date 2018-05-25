namespace CongDoan.Data.Infacstructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private CongDoanShopDbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public CongDoanShopDbContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}