using System;
using System.Threading;

namespace LianZhao.Threading
{
    public static class CancellationTokenSourceExtensions
    {
        public static void SafeCancel(
            this CancellationTokenSource source,
            Func<Exception, bool> exceptionHandler = null)
        {
            try
            {
                source.Cancel();
            }
            catch (ObjectDisposedException ex)
            {
                // do nothing, omit this exception
            }
            catch (AggregateException ex)
            {
                var handled = true;
                if (exceptionHandler != null)
                {
                    foreach (var innerException in ex.Flatten().InnerExceptions)
                    {
                        handled = exceptionHandler.Invoke(innerException);
                        if (!handled)
                        {
                            break;
                        }
                    }
                }

                if (!handled)
                {
                    throw;
                }
            }
        }
    }
}