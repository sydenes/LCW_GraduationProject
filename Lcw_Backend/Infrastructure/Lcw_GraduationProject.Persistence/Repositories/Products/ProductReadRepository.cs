using Lcw_GraduationProject.Application.Repositories.Products;
using Lcw_GraduationProject.Application.ViewModels.Products;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        private readonly LcwAPIDbContext _context;
        public ProductReadRepository(LcwAPIDbContext context) : base(context)
        {
            this._context = context;
        }

        public List<VM_Create_Product> GetByCategoryAsync(string id, bool tracking = true)
        {
            var products = _context.Products.Where(x => x.CategoryId == Guid.Parse(id)).ToList();
            List<VM_Create_Product> vm = new List<VM_Create_Product>();

            //TODO: Convert işlemi gerçekleşecek  AutoMapper ile gerçekleştir!

            return null;
        }
    }
}
