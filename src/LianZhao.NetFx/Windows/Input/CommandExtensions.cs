using System.Windows.Input;

namespace LianZhao.Windows.Input
{
    public static class CommandExtensions
    {
        public static bool TryExecute(this ICommand command, object parameter)
        {
            if (command.CanExecute(parameter))
            {
                command.Execute(parameter);
                return true;
            }

            return false;
        }

        public static bool TryExecute(this ICommand command)
        {
            return command.TryExecute(null);
        }

        public static void Execute(this ICommand command)
        {
            command.Execute(null);
        }

        public static bool CanExecute(this ICommand command)
        {
            return command.CanExecute(null);
        }
    }
}