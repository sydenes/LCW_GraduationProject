using Lcw_GraduationProject.Application.ViewModels.Users;
using Lcw_GraduationProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.Repositories.Users
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        bool GetByMailAsync(VM_Login_User user, bool tracking = true);
    }
}
