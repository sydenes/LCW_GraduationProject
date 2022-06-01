using Lcw_GraduationProject.Application.Repositories.Customers;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Customers
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository //ReadRepository: Temel metotların Customer class'ı için uygulanabilmesini sağlar. ICustomerRepository: Bu repository'nin imzasıdır DependcyInjection ile erişime imkan verir.
    {
        public CustomerReadRepository(LcwAPIDbContext context) : base(context)
        {
        }
    }
}
