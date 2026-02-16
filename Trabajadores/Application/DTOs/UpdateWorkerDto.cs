using Trabajadores.Domain.Enums;

namespace Trabajadores.Application.DTOs
{
    public record UpdateWorkerDto(
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
