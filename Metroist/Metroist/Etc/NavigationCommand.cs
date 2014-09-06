using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;
using System;

namespace MetroistLib.Commands
{
    public class NavigationCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            Uri outUri = null;
            return Uri.TryCreate(parameter.ToString(), UriKind.RelativeOrAbsolute, out outUri);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(parameter.ToString());
            task.Show();
        }
    }
}
