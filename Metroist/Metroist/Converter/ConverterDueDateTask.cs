﻿using System;
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
            QueryDataItem _value = (QueryDataItem)value;
            string result = "";

            if (_value != null && _value.due_date != null && _value.due_date != string.Empty)
            {
                DateTime dueDate = DateTime.Parse(_value.due_date);

                if (dueDate.Date == DateTime.Now.Date)
                    result = "Today";
                else if (dueDate.Date == DateTime.Now.AddDays(1).Date)
                    result = "Tomorrow";
                else if (CheckDateIsOnActualWeek(dueDate))
                    result = dueDate.ToString("dddd", CultureInfo.InvariantCulture);
                else
                    result = dueDate.ToString("dd MMM", CultureInfo.InvariantCulture);

                //23:59:59 if there's no time associated
                if (dueDate.TimeOfDay != new TimeSpan(23, 59, 59))
                {
                    result += dueDate.ToString(" @ h:mm", CultureInfo.InvariantCulture);
                    result += dueDate.ToString("tt", CultureInfo.InvariantCulture).ToLowerInvariant();
                }
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
