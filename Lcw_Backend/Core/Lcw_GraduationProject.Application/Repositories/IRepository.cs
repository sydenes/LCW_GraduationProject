using Lcw_GraduationProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.Repositories
{
    public interface IRepository<T> where T:BaseEntity //DbSet zorunlu olarak class ile çalıştığından buraya class gönderimini zorunlu kıldık (T:TEntity)
    {
        DbSet<T> Table { get; }
    }
}
