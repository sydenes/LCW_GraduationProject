using Lcw_GraduationProject.Application.Repositories.Categories;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Categories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(LcwAPIDbContext context) : base(context)
        {
        }
    }
}
