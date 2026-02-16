using Microsoft.AspNetCore.Mvc;
using Trabajadores.Application.DTOs;
using Trabajadores.Application.Services;
using Trabajadores.Domain.Enums;

namespace Trabajadores.Controllers
{
    [ApiController]
    [Route("api/workers")]
    public class WorkersController : ControllerBase
    {
        private readonly WorkerService _service;

        public WorkersController(WorkerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var worker = await _service.GetById(id);
            return worker == null ? NotFound() : Ok(worker);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] CreateWorkerDto dto)
        {
            var id = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }


        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Put(Guid id, [FromForm] UpdateWorkerDto dto)
        {
            var ok = await _service.Update(id, dto);
            return ok ? NoContent() : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.Delete(id);
            return ok ? NoContent() : NotFound();
        }
        [HttpGet("gender/{gender}")]
        public async Task<IActionResult> GetByGender(Gender gender)
            => Ok(await _service.GetByGender(gender));

    }
}
