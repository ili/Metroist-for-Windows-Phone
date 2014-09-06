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
using System.Globalization;
using MetroistLib.Model;

namespace Metroist.Converter
{
    public class ConverterDueDateTask : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Item _value = (Item)value;
            string result = "";

            if (_value != null && _value.due_date != null && _value.due_date != string.Empty)
            {
                DateTime dueDate = DateTime.Parse(_value.due_date);
                result = GeneralLib.Utils.DateTimeToString(dueDate);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool CheckDateIsOnActualWeek(DateTime date)
        {
            var firstDayOfWeek = DateTime.Now.AddDays(DateTime.Now.DayOfWeek.GetHashCode() * (-1));
            var lastDayOfWeek = DateTime.Now.AddDays(6 - DateTime.Now.DayOfWeek.GetHashCode());

            return date >= firstDayOfWeek && date <= lastDayOfWeek;
        }
    }
}
