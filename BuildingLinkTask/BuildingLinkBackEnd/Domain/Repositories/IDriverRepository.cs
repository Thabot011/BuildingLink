using Domain.Entites;

namespace Domain.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllAsync(Constants.Constants.SortDirection sortDirection);
        Task<Driver> GetByIdAsync(int id, Constants.Constants.SortDirection sortdirection);
        Task<int> InsertAsync(Driver driver);
        Task<int> UpdateAsync(Driver driver);
        Task<int> DeleteAsync(int id);
        Task<int> BulkInsertAsync(List<Driver> drivers);
        Task InitDrivertableAsync();
    }
}
