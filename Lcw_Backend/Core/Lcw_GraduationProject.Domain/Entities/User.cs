using Lcw_GraduationProject.Domain.Entities.Common;

namespace Lcw_GraduationProject.Domain.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
