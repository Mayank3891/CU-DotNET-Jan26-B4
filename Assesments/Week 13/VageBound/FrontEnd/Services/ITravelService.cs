using FrontEnd.Models;
namespace FrontEnd.Services
{
    public interface ITravelService
    {
        Task <IEnumerable<Destination>> GetAllAsync();
    }
}
