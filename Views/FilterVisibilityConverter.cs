using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CTTManagement.Views
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class FilterVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isSelected = System.Convert.ToBoolean(value);

            return isSelected ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var v = (Visibility)value;
            return v == Visibility.Hidden ? false : true;
        }
    }
}
