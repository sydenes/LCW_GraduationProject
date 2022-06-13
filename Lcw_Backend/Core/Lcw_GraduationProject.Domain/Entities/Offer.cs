using Lcw_GraduationProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Domain.Entities
{
    public class Offer:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
