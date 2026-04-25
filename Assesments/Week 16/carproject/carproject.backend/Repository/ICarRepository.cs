using carproject.backend.Model;
using Microsoft.EntityFrameworkCore;
namespace carproject.backend.Repository
{
    public interface ICarRepository
    {

        Task<IEnumerable<Car>> GetAllAsync();

        Task<Car?> GetByIdAsync(int id);

        Task<Car> AddAsync(Car car);

        Task UpdateAsync(Car car);

        Task DeleteAsync(Car car);
    }
}
