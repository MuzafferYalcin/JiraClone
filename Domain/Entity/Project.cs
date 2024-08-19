using Domain.Entity.EntityBase;

namespace Domain.Entity
{
    public sealed class Project : BaseEntity
    {
        public string Name {get; set;}
        public ICollection<Ticket>? Tickets{get; set;}
    }
}
