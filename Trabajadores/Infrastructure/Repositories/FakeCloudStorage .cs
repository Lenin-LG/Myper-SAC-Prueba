using Trabajadores.Domain.Ports.@out;

namespace Trabajadores.Infrastructure.Repositories
{
    public class FakeCloudStorage : IFileStorage
    {
        public Task<string> SaveAsync(IFormFile file)
        {
            var url = $"https://fakecloud.com/workers/{Guid.NewGuid()}_{file.FileName}";
            return Task.FromResult(url);
        }
    }
}
