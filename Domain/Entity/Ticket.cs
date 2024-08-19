using System.ComponentModel.DataAnnotations;
using Domain.Entity.EntityBase;

namespace Domain.Entity;

public sealed class Ticket : BaseEntity
{
    [MaxLength(100)]
    public string Title { get; set; }
    [MaxLength(400)]
    public string Description { get; set; }
    public ICollection<User>? ResponsibleUsers { get; set; }
    public User? CreatedByUser { get; set; }
    public User? UpdatedByUser { get; set; }
    public User? DeletedByUser { get; set; }
    public Project Project { get; set; }
    public int ProjectId { get; set; }
}