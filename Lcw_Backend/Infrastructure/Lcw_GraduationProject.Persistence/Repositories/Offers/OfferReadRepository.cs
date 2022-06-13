using Lcw_GraduationProject.Application.Repositories.Offers;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Offers
{
    public class OfferReadRepository : ReadRepository<Offer>, IOfferReadRepository
    {
        public OfferReadRepository(LcwAPIDbContext context) : base(context)
        {
        }
    }
}
