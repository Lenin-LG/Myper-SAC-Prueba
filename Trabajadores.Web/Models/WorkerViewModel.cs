namespace Trabajadores.Web.Models
{
    public class WorkerViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
