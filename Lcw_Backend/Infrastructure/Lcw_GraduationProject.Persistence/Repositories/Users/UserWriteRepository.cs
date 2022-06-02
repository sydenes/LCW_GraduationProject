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
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(LcwAPIDbContext context) : base(context)
        {
        }
    }
}
