using System;
using System.Windows.Input;

namespace LianZhao.Windows.Input
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecuteFunc;
        private readonly Action<T> _executeAction;

        public DelegateCommand(Action<T> executeAction, Predicate<T> canExecuteFunc = null)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }

            _canExecuteFunc = canExecuteFunc;
            _executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunc == null)
            {
                return true;
            }

            if (parameter is T || parameter == null)
            {
                return _canExecuteFunc.Invoke((T)parameter);
            }

            return false;
        }

        public void Execute(object parameter)
        {
            _executeAction.Invoke((T)parameter);
        }

        public void RaiseCanExecuteChangedEvent()
        {
            OnCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}