using AutoMapper;
using CarManagement.Application.DTOs;

using carproject.backend.Model;
using carproject.backend.Repository;
using carproject.backend.Service;

namespace carproject.backend.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repo;
        private readonly IMapper _mapper;

        public CarService(ICarRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            var cars = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var car = await _repo.GetByIdAsync(id);

            if (car == null)
                throw new Exception("Car not found");

            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> CreateAsync(CreateCarDto dto)
        {
            var car = _mapper.Map<Car>(dto);

            if (dto.Year < 2000)
                throw new Exception("Invalid year");

            var created = await _repo.AddAsync(car);

            return _mapper.Map<CarDto>(created);
        }

        public async Task<CarDto> UpdateAsync(int id, CreateCarDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Car not found");

            _mapper.Map(dto, existing);

            await _repo.UpdateAsync(existing);

            return _mapper.Map<CarDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var car = await _repo.GetByIdAsync(id);

            if (car == null)
                return false;

            await _repo.DeleteAsync(car);

            return true;
        }
    }
}