using Domain.Entity.EntityBase;

namespace Domain.DTOs;

public sealed class UserDto : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}