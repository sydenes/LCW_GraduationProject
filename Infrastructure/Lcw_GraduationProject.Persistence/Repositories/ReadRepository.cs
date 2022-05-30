using Lcw_GraduationProject.Application.Repositories;
using Lcw_GraduationProject.Domain.Entities.Common;
using Lcw_GraduationProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lcw_GraduationProject.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly LcwAPIDbContext _context;

        public ReadRepository(LcwAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //Generic gelen Entity class'ı Set<T> ile DbSet'e eşlendi.

        public IQueryable<T> GetAll()
            => Table;

        public async Task<T> GetByIdAsync(string id)
            =>await Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
            =>await Table.FirstOrDefaultAsync(filter);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
            => Table.Where(filter);
    }
}
