using Lcw_GraduationProject.Application.Repositories.Orders;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Orders
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(LcwAPIDbContext context) : base(context)
        {
        }
    }
}
