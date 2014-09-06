using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Metroist.Pages
{
    public partial class AddNotePage : PhoneApplicationPage
    {
        App app = Application.Current as App;
        public static MetroistLib.Model.Item Task;
        public static MetroistLib.Model.Project Project;

        private ApplicationBarIconButton doneButton = GeneralLib.Utils.createDoneButton("done");

        public AddNotePage()
        {
            InitializeComponent();
            DataContext = Task;
            CreateApplicationBar();
        }

        private void CreateApplicationBar()
        {
            Converter.ConverterProjectColor converter = new Converter.ConverterProjectColor();
            Color BackgroundColor = ((SolidColorBrush)converter.Convert(Project.color, null, null, null)).Color;

            if (Project.color == 20)
                ApplicationBar = Utils.CreateApplicationBar(BackgroundColor, (Color)App.Current.Resources["WhiteColor2"]);
            else
                ApplicationBar = Utils.CreateApplicationBar(BackgroundColor);

            doneButton.Click += doneButton_Click;

            ApplicationBar.Buttons.Add(doneButton);

            ApplicationBar.IsVisible = true;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            TodoistService todoistService = new TodoistService();

            var commandTimeGenerated = DateTime.Now;
            doneButton.IsEnabled = false;
            todoistService.AddNoteToTask(commandTimeGenerated, Task.id, NoteTextBox.Text,
            (data) =>
            {
                todoistService.GetData(
                (fullData) =>
                {
                    MainTodoistPage.updateAll(fullData);
                    var taskFromUpdate = app.items.First(y => y.id == Task.id);
                    if (taskFromUpdate != null)
                    {
                        TaskDetail.Task = taskFromUpdate;
                        TaskDetail.needsUpdateView = true;
                    }
                },
                (error) =>
                {
                    MessageBox.Show(Utils.Message(error), "Metroist", MessageBoxButton.OK);
                },
                () =>
                {
                    NavigationService.GoBack();
                });
            },
            (message) =>
            {
                MessageBox.Show(Utils.Message(message), "Metroist", MessageBoxButton.OK);
            },
            () =>
            {
            });
        }

        private void NoteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}