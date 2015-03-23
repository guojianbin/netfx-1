using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LianZhao.Data.Entity
{
    public interface IAsyncQueryProvider
    {
        Task<TSource> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TSource> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TSource>> ToListAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TSource[]> ToArrayAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}