using Lcw_GraduationProject.Application.Repositories;
using Lcw_GraduationProject.Domain.Entities.Common;
using Lcw_GraduationProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lcw_GraduationProject.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity //Marker Pattern kullanılarak gönderilen class'ın spesifik olarak BaseEntity'den türeyecek bir class olduğunu belirterek Lambda Expression ile 'id' bilgisine generic olarak ulaştık.
    {
        private readonly LcwAPIDbContext _context;

        public ReadRepository(LcwAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //Generic gelen Entity class'ı Set<T> ile DbSet'e eşlendi.

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) //Tracking: EfCore'un database'den gelen verileri takip eden mekanizması. Optimizasyon için gerek olmayan kısımlar tracking'i kapatabileceğimiz bir kontrol yapısı ekledik. Tracking kapatılırsa SaveChanges metotu db'yi o nesne için etkilemez.
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //=> await Table.FindAsync(Guid.Parse(id)); //marker yerine kullanılabilir ancak Queryable'da Find metotu bulunmadığı için marker'la devam ettik.
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
