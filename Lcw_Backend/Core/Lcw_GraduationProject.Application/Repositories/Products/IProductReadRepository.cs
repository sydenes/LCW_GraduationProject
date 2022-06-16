using Lcw_GraduationProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.Repositories.Products
{
    public interface IProductReadRepository:IReadRepository<Product>
    {
        IEnumerable<Product> GetMyProducts(string userId);
    }
}
