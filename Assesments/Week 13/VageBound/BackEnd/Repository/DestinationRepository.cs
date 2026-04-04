using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using BackEnd.Exceptions;
namespace BackEnd.Repository
{
   
        public class DestinationRepository : IDestinationRepository
        {
            private readonly BackEndContext _context;

            public DestinationRepository(BackEndContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Destination>> GetAllAsync() =>
                await _context.Destination.ToListAsync();

            public async Task<Destination?> GetByIdAsync(int id) =>

                await _context.Destination.FindAsync(id);

            public async Task AddAsync(Destination destination)
            {
                _context.Destination.Add(destination);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Destination destination)
            {
                _context.Destination.Update(destination);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var destination = await _context.Destination.FindAsync(id);
                if (destination == null)
                    throw new DestinationNotFoundException(id);

                _context.Destination.Remove(destination);
                await _context.SaveChangesAsync();
            }
        }

    }

