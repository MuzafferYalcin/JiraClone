using Domain.Entity.EntityBase;

namespace Domain.Entity
{
    public sealed class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<Ticket>? DeletedTickets { get; set; }
        public ICollection<Ticket>? CreatedTickets { get; set; }
        public ICollection<Ticket>? UpdatedTickets { get; set; }
        public ICollection<Ticket>? ResponsibleTickets { get; set; }
    }
}