using System.Threading.Tasks;

namespace LianZhao.Threading.Tasks
{
    public class AggregatedExceptionAwaitable
    {
        private readonly Task _task;

        public AggregatedExceptionAwaitable(Task task)
        {
            _task = task;
        }

        public AggregatedExceptionAwaiter GetAwaiter()
        {
            return new AggregatedExceptionAwaiter(_task);
        }
    }

    public class AggregatedExceptionAwaitable<T>
    {
        private readonly Task<T> _task;

        public AggregatedExceptionAwaitable(Task<T> task)
        {
            _task = task;
        }

        public AggregatedExceptionAwaiter<T> GetAwaiter()
        {
            return new AggregatedExceptionAwaiter<T>(_task);
        }
    }
}