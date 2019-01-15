using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace TikTacToe.UI
{
    public class FieldConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<FieldPresenter> list && parameter is string text && int.TryParse(text, out int index))
            {
                return list[index];
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}