using Lcw_GraduationProject.Domain.Entities.Common;

namespace Lcw_GraduationProject.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsSold { get; set; }
        public bool IsOfferable { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
