using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Linq;
using MetroistLib.Model;
using System.Collections.Generic;

namespace Metroist.Converter
{
    public class ConverterCountingTasksFromProject : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            App app = Application.Current as App;
            Project _value = (Project)value;

            IEnumerable<Item> list = app.items.Where(x => x.project_id == _value.id);
            List<Item> listItemsFromProject = list != null ? list.ToList() : null;

            string result = "";
            if (listItemsFromProject != null && listItemsFromProject.Count > 0)
            {
                if (listItemsFromProject.Count > 99)
                {
                    result = "+99";
                }
                else
                {
                    result = listItemsFromProject.Count.ToString();
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
