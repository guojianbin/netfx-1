using System;
using System.Threading.Tasks;

namespace LianZhao.Threading.Tasks
{
    public class AggregatedExceptionAwaiter
    {
        private readonly Task _task;

        public AggregatedExceptionAwaiter(Task task)
        {
            _task = task;
        }

        public bool IsCompleted
        {
            get { return _task.GetAwaiter().IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            _task.GetAwaiter().OnCompleted(continuation);
        }

        public void GetResult()
        {
            _task.Wait();
        }
    }
    public class AggregatedExceptionAwaiter<T>
    {
        private readonly Task<T> _task;

        public AggregatedExceptionAwaiter(Task<T> task)
        {
            _task = task;
        }

        public bool IsCompleted
        {
            get { return _task.GetAwaiter().IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            _task.GetAwaiter().OnCompleted(continuation);
        }

        public T GetResult()
        {
            _task.Wait();
            return _task.Result;
        }
    }
}