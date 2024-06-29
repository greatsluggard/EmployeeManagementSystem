using StorageService.Domain.Interfaces.Repository;

namespace StorageService.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("The entity passed for create is null");
            }

            await _dbContext.AddAsync(entity);

            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("The entity passed for update is null");
            }

            _dbContext.Update(entity);

            return entity;
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("The entity passed for remove is null");
            }

            _dbContext.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}