using Microsoft.Identity.Client.Extensions.Msal;
using Trabajadores.Application.DTOs;
using Trabajadores.Domain.Enums;
using Trabajadores.Domain.Ports;
using Trabajadores.Domain.Ports.@out;

namespace Trabajadores.Application.Services
{
    public class WorkerService
    {
        private readonly IWorkerRepository _repo;
        private readonly IFileStorage _storage;
        public WorkerService(IWorkerRepository repo, IFileStorage storage)
        {
            _repo = repo;
            _storage = storage;
        }

        public async Task<IEnumerable<WorkerDto>> GetAll()
        {
            var workers = await _repo.GetAllAsync();
            return workers.Select(ToDto);
        }

        public async Task<WorkerDto?> GetById(Guid id)
        {
            var worker = await _repo.GetByIdAsync(id);
            return worker == null ? null : ToDto(worker);
        }

        public async Task<Guid> Create(CreateWorkerDto dto)
        {
            string? photoUrl = null;

            if (dto.Photo != null)
                photoUrl = await _storage.SaveAsync(dto.Photo);

            var worker = new Worker(
                dto.FirstName,
                dto.LastName,
                dto.DocumentType,
                dto.DocumentNumber,
                dto.Gender,
                dto.BirthDate,
                dto.Address,
                photoUrl);


            await _repo.AddAsync(worker);
            return worker.Id;
        }


        public async Task<bool> Update(Guid id, UpdateWorkerDto dto)
        {
            var worker = await _repo.GetByIdAsync(id);
            if (worker == null) return false;

            worker.Update(
                dto.FirstName,
                dto.LastName,
                dto.DocumentType,
                dto.DocumentNumber,
                dto.Gender,
                dto.BirthDate,
                dto.Address

            );

            if (dto.Photo != null)
            {
                var photoUrl = await _storage.SaveAsync(dto.Photo);
                worker.SetPhoto(photoUrl);
            }

            await _repo.UpdateAsync(worker);
            return true;
        }


        public async Task<bool> Delete(Guid id)
        {
            var worker = await _repo.GetByIdAsync(id);
            if (worker == null) return false;

            await _repo.DeleteAsync(id);
            return true;
        }
        public async Task<IEnumerable<WorkerDto>> GetByGender(Gender gender)
        {
            var workers = await _repo.GetByGenderAsync(gender);
            return workers.Select(ToDto);
        }


        private static WorkerDto ToDto(Worker w)
            => new WorkerDto(
                w.Id,
                w.FirstName,
                w.LastName,
                w.DocumentType,
                w.DocumentNumber,
                w.Gender,
                w.BirthDate,
                w.Address,
                w.PhotoUrl
            );
    }
}
