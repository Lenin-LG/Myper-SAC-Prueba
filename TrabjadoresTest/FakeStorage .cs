using Microsoft.AspNetCore.Http;
using Trabajadores.Domain.Ports.@out;

public class FakeStorage : IFileStorage
{
    public Task<string> SaveAsync(IFormFile file)
        => Task.FromResult("https://fakeurl.com/test.jpg");
}
