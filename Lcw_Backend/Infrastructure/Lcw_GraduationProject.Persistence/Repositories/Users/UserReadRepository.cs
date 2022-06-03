using Lcw_GraduationProject.Application.Repositories.Users;
using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Persistence.Repositories.Users
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository //ReadRepository: Temel metotların Customer class'ı için uygulanabilmesini sağlar. ICustomerRepository: Bu repository'nin imzasıdır DependcyInjection ile erişime imkan verir.
    {
        private readonly LcwAPIDbContext _context;
        public UserReadRepository(LcwAPIDbContext context) : base(context)
        {
            this._context = context;
        }

        public bool GetByMailAsync(string mail, bool tracking = true)
        {
            var user = _context.Users.FirstOrDefault(u => u.Mail == mail);
            if(user !=null)
                return true;
            return false;
        }
    }
}
