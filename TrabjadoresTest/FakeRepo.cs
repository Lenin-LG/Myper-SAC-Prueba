using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajadores.Domain.Enums;
using Trabajadores.Domain.Ports.@out;

namespace TrabjadoresTest
{
    public class FakeRepo : IWorkerRepository
    {
        public List<Worker> data = new();
        public Task AddAsync(Worker worker) { data.Add(worker); return Task.CompletedTask; }
        public Task DeleteAsync(Guid id) { return Task.CompletedTask; }
        public Task<IEnumerable<Worker>> GetAllAsync() 
              => Task.FromResult(data.AsEnumerable());

        public Task<IEnumerable<Worker>> GetByGenderAsync(Gender gender)
            => Task.FromResult(data.Where(x => x.Gender == gender).AsEnumerable());


        public Task<Worker?> GetByIdAsync(Guid id)
              => Task.FromResult(data.FirstOrDefault(x => x.Id == id));

        public Task UpdateAsync(Worker worker) => Task.CompletedTask;
    }
}
