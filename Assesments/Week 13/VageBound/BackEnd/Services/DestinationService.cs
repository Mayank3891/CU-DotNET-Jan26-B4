using BackEnd.Models;
using BackEnd.Repository;
using BackEnd.Exceptions;

namespace BackEnd.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var destinations = await _repository.GetAllAsync();
            if (!destinations.Any())
                throw new Exception("No destinations found.");
            return destinations;
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _repository.GetByIdAsync(id);
            if (destination == null)
                throw new DestinationNotFoundException(id);
            return destination;
        }

        public async Task AddAsync(Destination destination)
        {
          
            await _repository.AddAsync(destination);
        }

        public async Task UpdateAsync(Destination destination)
        {
            
            await _repository.UpdateAsync(destination);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}