using Lcw_GraduationProject.Application.ViewModels.Offers;
using Lcw_GraduationProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.Repositories.Offers
{
    public interface IOfferReadRepository : IReadRepository<Offer>
    {
        Offer ReadOffer(string productId,string userId);
        List<VM_Get_OfferDetail> OfferList(string userId);
        List<VM_Get_OfferDetail> OthersOfferList(string userId);
    }
}
