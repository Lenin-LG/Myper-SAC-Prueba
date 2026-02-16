namespace Trabajadores.Domain.Ports.@out
{
    public interface IFileStorage
    {
        Task<string> SaveAsync(IFormFile file);
    }
}
