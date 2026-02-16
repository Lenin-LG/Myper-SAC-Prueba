

using Trabajadores.Domain.Enums;

namespace Trabajadores.Domain.Ports.@out
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> GetAllAsync();
        Task<Worker?> GetByIdAsync(Guid id);
        Task AddAsync(Worker worker);
        Task UpdateAsync(Worker worker);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Worker>> GetByGenderAsync(Gender gender);

    }
}
