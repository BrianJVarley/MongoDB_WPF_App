﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

// <author>Brian Varley</author>
// <summary>BoolToVisibilityConverter</summary>

namespace MongoDBApp.Converters
{
    /// <summary>
    /// BoolToVisibilityConverter
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType,
         object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to visibility
            bool bValue = (bool)value;
            if (bValue)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // Do the conversion from visibility to bool
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        }


    }
}

