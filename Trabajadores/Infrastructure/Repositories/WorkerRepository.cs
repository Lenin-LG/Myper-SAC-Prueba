
using Trabajadores.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Trabajadores.Domain.Ports.@out;
using Trabajadores.Domain.Enums;

namespace Trabajadores.Infrastructure.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly WorkerDbContext _db;

        public WorkerRepository(WorkerDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Worker>> GetByGenderAsync(string gender)
        
           => await _db.Workers.FromSqlRaw("EXEC GetWorkersByGender @p0", gender).ToListAsync();


        public async Task<IEnumerable<Worker>> GetAllAsync()
            => await _db.Workers.FromSqlRaw("EXEC GetWorkers").ToListAsync();
        


        public async Task<Worker?> GetByIdAsync(Guid id)
            => await _db.Workers.FindAsync(id);

        public async Task AddAsync(Worker worker)
        {
            await _db.Workers.AddAsync(worker);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Worker worker)
        {
            _db.Workers.Update(worker);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var w = await _db.Workers.FindAsync(id);
            if (w != null)
            {
                _db.Workers.Remove(w);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Worker>> GetByGenderAsync(Gender gender)
        {
            return await _db.Workers
                .Where(w => w.Gender == gender)
                .ToListAsync();
        }

    }
}
