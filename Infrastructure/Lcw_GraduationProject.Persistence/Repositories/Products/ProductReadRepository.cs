using Lcw_GraduationProject.Application.Repositories.Products;
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
        public ProductReadRepository(LcwAPIDbContext context) : base(context)
        {
        }
    }
}
