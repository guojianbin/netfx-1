using System;

namespace LianZhao
{
    public class SimpleProgress<T> : IProgress<T>
    {
        public SimpleProgress()
        {
        }

        public SimpleProgress(Action<T> action)
            : this()
        {
            ProgressChanged += (s, e) => action.Invoke(e);
        }

        public event EventHandler<T> ProgressChanged;

        #region Implementation of IProgress<in T>

        void IProgress<T>.Report(T value)
        {
            OnProgressChanged(value);
        }

        #endregion

        private void OnProgressChanged(T e)
        {
            var handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}