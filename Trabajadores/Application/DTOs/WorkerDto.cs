
using Trabajadores.Domain.Enums;

namespace Trabajadores.Application.DTOs
{
    public record WorkerDto(
        Guid Id,
        string FirstName,
        string LastName,
        DocumentType DocumentType,
        string DocumentNumber,
        Gender Gender,
        DateTime BirthDate,
        string Address,
        string? PhotoUrl
    );
}
