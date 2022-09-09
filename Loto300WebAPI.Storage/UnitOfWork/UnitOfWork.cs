namespace Loto300WebAPI.Storage.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILottoDbContextcs _dbContext;

        public UnitOfWork(ILottoDbContextcs dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> SaveChangesAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}
