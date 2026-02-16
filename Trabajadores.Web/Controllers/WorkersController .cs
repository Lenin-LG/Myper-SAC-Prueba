using Microsoft.AspNetCore.Mvc;
using Trabajadores.Web.Models;
using Trabajadores.Web.Services;
using static System.Net.WebRequestMethods;

namespace Trabajadores.Web.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkerApiService _api;

        public WorkersController(WorkerApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index(string? gender)
        {
            if (!string.IsNullOrEmpty(gender))
                return View(await _api.GetByGender(int.Parse(gender)));

            return View(await _api.GetAll());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile Photo, WorkerViewModel model)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(model.FirstName), "FirstName");
            content.Add(new StringContent(model.LastName), "LastName");
            content.Add(new StringContent(model.DocumentType.ToString()), "DocumentType");
            content.Add(new StringContent(model.DocumentNumber), "DocumentNumber");
            content.Add(new StringContent(model.Gender.ToString()), "Gender");
            content.Add(new StringContent(model.BirthDate.ToString("o")), "BirthDate");
            content.Add(new StringContent(model.Address), "Address");

            if (Photo != null)
            {
                content.Add(new StreamContent(Photo.OpenReadStream()), "Photo", Photo.FileName);
            }

            await _api.Create(content);

            TempData["Success"] = "Trabajador creado correctamente";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _api.Delete(id);

            TempData["Success"] = "Trabajador eliminado correctamente";
            return RedirectToAction("Index");
        }
    
        public async Task<IActionResult> Edit(Guid id)
        {
            var worker = await _api.GetById(id);
            if (worker == null)
                return NotFound();
            return View(worker);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, WorkerViewModel model, IFormFile Photo)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(model.FirstName), "FirstName");
            content.Add(new StringContent(model.LastName), "LastName");
            content.Add(new StringContent(model.DocumentType.ToString()), "DocumentType");
            content.Add(new StringContent(model.DocumentNumber), "DocumentNumber");
            content.Add(new StringContent(model.Gender.ToString()), "Gender");
            content.Add(new StringContent(model.BirthDate.ToString("o")), "BirthDate");
            content.Add(new StringContent(model.Address), "Address");

            if (Photo != null)
                content.Add(new StreamContent(Photo.OpenReadStream()), "Photo", Photo.FileName);

            await _api.Update(id, content);

            TempData["Success"] = "Trabajador actualizado correctamente";
            return RedirectToAction("Index");
        }


    }
}
