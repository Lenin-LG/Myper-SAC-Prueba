using Trabajadores.Domain.Enums;

namespace Trabajadores.Application.DTOs
{
    public record CreateWorkerDto(
    string FirstName,
    string LastName,
    DocumentType DocumentType,
    string DocumentNumber,
    Gender Gender,
    DateTime BirthDate,
    string Address,
    IFormFile? Photo
    );

}
