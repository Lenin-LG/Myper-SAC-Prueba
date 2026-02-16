using Trabajadores.Application.DTOs;
using Trabajadores.Application.Services;
using Trabajadores.Domain.Enums;
using TrabjadoresTest;

public class WorkerServiceTests
{
    [Fact]
    public async Task Should_Create_Worker()
    {
        var repo = new FakeRepo();
        var storage = new FakeStorage();
        var service = new WorkerService(repo, storage);

        var id = await service.Create(new CreateWorkerDto(
            "Juan",
            "Perez",
            DocumentType.DNI,
            "123",
            Gender.Masculino,
            DateTime.Now,
            "Lima",
            null
        ));

        Assert.Single(repo.data);
        Assert.NotEqual(Guid.Empty, id);
        Assert.Equal("Juan", repo.data.First().FirstName);
        Assert.Equal(Gender.Masculino, repo.data.First().Gender);
    }
}
