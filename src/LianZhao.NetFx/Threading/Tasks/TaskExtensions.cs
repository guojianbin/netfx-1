using System.Threading.Tasks;

namespace LianZhao.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static AggregatedExceptionAwaitable WithAggregatedExceptions(this Task task)
        {
            return new AggregatedExceptionAwaitable(task);
        }
        public static AggregatedExceptionAwaitable<T> WithAggregatedExceptions<T>(this Task<T> task)
        {
            return new AggregatedExceptionAwaitable<T>(task);
        }
    }
}