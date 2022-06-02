using Lcw_GraduationProject.Domain.Entities.Common;

namespace Lcw_GraduationProject.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
