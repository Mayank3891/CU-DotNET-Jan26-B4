using CarManagement.Application.DTOs;
using carproject.backend.Model;

namespace carproject.backend.Service
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllAsync();

        Task<CarDto> GetByIdAsync(int id);

        Task<CarDto> CreateAsync(CreateCarDto dto);

        Task<CarDto> UpdateAsync(int id, CreateCarDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
