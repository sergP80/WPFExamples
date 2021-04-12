using System;
using System.Windows.Input;

namespace SharedResources
{
    public class RelayCommand<T> : ICommand
    {
        readonly Action<T> _execute;
        readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void RefreshCommand()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : base(_ => execute(),
                _ => canExecute == null || canExecute())
        {

        }
    }

    public static class SharedCommands 
    {
        public static RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(SharedCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F10, ModifierKeys.Control),
                    new KeyGesture(Key.Escape)
                }
            );
        
        public static RoutedUICommand AddNewItem = new RoutedUICommand
            (
                "New item",
                "NewItem",
                typeof(SharedCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F5, ModifierKeys.Shift)
                }
            );

        public static RoutedUICommand RemoveItem = new RoutedUICommand
            (
                "Remove item",
                "RemoveItem",
                typeof(SharedCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F4, ModifierKeys.Shift)
                }
            );
    }
}
