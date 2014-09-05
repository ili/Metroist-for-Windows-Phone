using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using MetroistLib.Component.MessageBox;

namespace Visual.Controls
{
    public partial class MessageBox : Grid
    {
        public enum CustomMessageBoxResult
        {
            Yes,
            No,
            Cancel
        }

        private PhoneApplicationPage _page;
        private MessageBox()
        {
            InitializeComponent();
        }
        public event EventHandler<MessageBoxEventArgs> Closed;
        protected virtual void OnClosed(CustomMessageBoxResult result)
        {

            // need to unsubscribe from the backkeypress
            _page.BackKeyPress -= Page_BackKeyPress;
            var handler = this.Closed;
            if (handler != null)
            {
                handler(this, new MessageBoxEventArgs
                {
                    Result = result
                });
            }
            Remove();
        }
        public static MessageBox Show(string message, string caption, string yesButtonText, string noButtonText = null)
        {
            MessageBox msgBox = new MessageBox();
            msgBox.HeaderTextBlock.Text = caption;
            msgBox.MessageTextBlock.Text = message;
            msgBox.YesButton.Content = yesButtonText;
            if (string.IsNullOrWhiteSpace(noButtonText))
            {
                msgBox.NoButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                msgBox.NoButton.Content = noButtonText;
            }
            msgBox.Insert();
            return msgBox;
        }
        private void Insert()
        {
            // Make an assumption that this is within a phone application that is developed "normally"
            var frame = Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame;
            _page = frame.Content as PhoneApplicationPage;
            _page.BackKeyPress += Page_BackKeyPress;
            // assume the child is a Grid, span all of the rows
            var grid = System.Windows.Media.VisualTreeHelper.GetChild(_page, 0) as Grid;
            if (grid.RowDefinitions.Count > 0)
            {
                Grid.SetRowSpan(this, grid.RowDefinitions.Count);
            }
            grid.Children.Add(this);
            // Create a transition like the regular MessageBox
            SwivelTransition transitionIn = new SwivelTransition();
            transitionIn.Mode = SwivelTransitionMode.BackwardIn;
            // Transition only the MessagePanel
            ITransition transition = transitionIn.GetTransition(MessagePanel);
            transition.Completed += (s, e) => transition.Stop();
            transition.Begin();
            if (_page.ApplicationBar != null)
            {
                // Hide the app bar so they cannot open more message boxes
                _page.ApplicationBar.IsVisible = false;
            }
        }
        private void Remove()
        {
            var frame = Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame;
            var page = frame.Content as PhoneApplicationPage;
            var grid = System.Windows.Media.VisualTreeHelper.GetChild(page, 0) as Grid;
            // Create a transition like the regular MessageBox
            SwivelTransition transitionOut = new SwivelTransition();
            transitionOut.Mode = SwivelTransitionMode.BackwardOut;
            ITransition transition = transitionOut.GetTransition(MessagePanel);
            transition.Completed += (s, e) =>
            {
                transition.Stop();
                grid.Children.Remove(this);
                if (page.ApplicationBar != null)
                {
                    page.ApplicationBar.IsVisible = true;
                }
            };
            transition.Begin();
        }
        private void Page_BackKeyPress(object sender, CancelEventArgs e)
        {
            OnClosed(CustomMessageBoxResult.Cancel);
            e.Cancel = true;
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            OnClosed(CustomMessageBoxResult.Yes);
        }
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            OnClosed(CustomMessageBoxResult.No);
        }
    }
}