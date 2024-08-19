namespace Domain.Entity.EntityBase
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

