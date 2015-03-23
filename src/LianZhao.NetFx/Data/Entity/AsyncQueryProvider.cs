using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LianZhao.Data.Entity
{
    public class AsyncQueryProvider : IAsyncQueryProvider
    {
        public static readonly AsyncQueryProvider Default = new AsyncQueryProvider();

        private AsyncQueryProvider()
        {
        }

        public Task<TSource> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(source.FirstOrDefault());
        }

        public Task<TSource> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(source.SingleOrDefault());
        }

        public Task<List<TSource>> ToListAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(source.ToList());
        }

        public Task<TSource[]> ToArrayAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(source.ToArray());
        }
    }
}