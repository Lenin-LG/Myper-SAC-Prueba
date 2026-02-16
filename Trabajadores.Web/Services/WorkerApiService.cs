using Trabajadores.Web.Models;

namespace Trabajadores.Web.Services
{
    public class WorkerApiService
    {
        private readonly HttpClient _http;

        public WorkerApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<WorkerViewModel>> GetAll()
        {
            var result = await _http.GetFromJsonAsync<List<WorkerViewModel>>("api/workers");
            return result ?? new List<WorkerViewModel>();
        }

        public async Task Create(MultipartFormDataContent content)
        {
            await _http.PostAsync("api/workers", content);
        }

        public async Task Delete(Guid id)
        {
            var response = await _http.DeleteAsync($"api/workers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error API: {response.StatusCode} - {error}");
            }
        }

        public async Task<List<WorkerViewModel>> GetByGender(int gender)
        {
            return await _http.GetFromJsonAsync<List<WorkerViewModel>>($"api/workers/gender/{gender}")
                   ?? new List<WorkerViewModel>();
        }
        public async Task Update(Guid id, MultipartFormDataContent content)
        {
            await _http.PutAsync($"api/workers/{id}", content);
        }
        public async Task<WorkerViewModel?> GetById(Guid id)
        {
            return await _http.GetFromJsonAsync<WorkerViewModel>($"api/workers/{id}");
        }


    }
}
