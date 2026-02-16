using Trabajadores.Domain.Enums;

public class Worker
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DocumentType DocumentType { get; private set; }
    public string DocumentNumber { get; private set; }
    public Gender Gender { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Address { get; private set; }
    public string? PhotoUrl { get; private set; }

    public Worker(
        string firstName,
        string lastName,
        DocumentType documentType,
        string documentNumber,
        Gender gender,
        DateTime birthDate,
        string address,
        string? photoUrl)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName requerido");

        FirstName = firstName;
        LastName = lastName;
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        Gender = gender;
        BirthDate = birthDate;
        Address = address;
        PhotoUrl = photoUrl;
    }

    public void Update(
        string firstName,
        string lastName,
        DocumentType documentType,
        string documentNumber,
        Gender gender,
        DateTime birthDate,
        string address)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName requerido");

        FirstName = firstName;
        LastName = lastName;
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        Gender = gender;
        BirthDate = birthDate;
        Address = address;
    }

    public void SetPhoto(string url)
    {
        PhotoUrl = url;
    }
}
