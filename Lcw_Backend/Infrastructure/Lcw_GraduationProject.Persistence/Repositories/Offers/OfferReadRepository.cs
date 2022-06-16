using Lcw_GraduationProject.Application.Repositories.Offers;
using Lcw_GraduationProject.Application.ViewModels.Offers;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Offers
{
    public class OfferReadRepository : ReadRepository<Offer>, IOfferReadRepository
    {
        private readonly LcwAPIDbContext _context;
        public OfferReadRepository(LcwAPIDbContext context) : base(context)
        {
            this._context = context;
        }

        public List<VM_Get_OfferDetail> OfferList(string userId)
        {
            List<VM_Get_OfferDetail> offerDetails = new List<VM_Get_OfferDetail>();
            VM_Get_OfferDetail offer;
            var offers = _context.Offers.Include(t => t.Product)
                .ThenInclude(t => t.User)
                .Where(o => o.UserId == Guid.Parse(userId) && o.IsActive).ToList();

            foreach (var item in offers)
            {
                offer = new VM_Get_OfferDetail();
                offer.UserName = item.Product.User.Mail;
                offer.ProductName = item.Product.Name;
                offer.Id = item.Id.ToString();
                offer.Price = item.Price;
                offer.Status = item.Status;
                offer.ProductId = item.ProductId.ToString();
                offerDetails.Add(offer);
            }
            return offerDetails;
        }
        public List<VM_Get_OfferDetail> OthersOfferList(string userId)
        {
            List<VM_Get_OfferDetail> offerDetails = new List<VM_Get_OfferDetail>();
            VM_Get_OfferDetail offer;
            var productIdList = _context.Products.Where(t => t.UserId == Guid.Parse(userId)).Select(t => t.Id).ToList();
            var offers = _context.Offers.Include(t => t.Product).ThenInclude(t => t.User).Where(o => productIdList.Contains(o.ProductId) && o.IsActive).ToList();
            foreach (var item in offers)
            {
                offer = new VM_Get_OfferDetail();
                offer.UserName = _context.Users.Find(item.UserId).Mail; //TODO: MAİL yerine isim+soyisim
                offer.ProductName = item.Product.Name;
                offer.Id = item.Id.ToString();
                offer.Price = item.Price;
                offer.Status = item.Status;
                offer.ProductId = item.ProductId.ToString();
                offerDetails.Add(offer);
            }
            return offerDetails;
        }

        public Offer ReadOffer(string productId, string userId)
        {
            return _context.Offers.Where(o => o.ProductId == Guid.Parse(productId) && o.UserId == Guid.Parse(userId) && o.IsActive == true).FirstOrDefault();
        }
    }
}
