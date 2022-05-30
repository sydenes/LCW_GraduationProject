namespace Lcw_GraduationProject.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
