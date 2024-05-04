namespace BookShop.DAL.MainRepository
{
    public interface IMainRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int Id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int Id);

        Task SaveAsync();
    }
}
