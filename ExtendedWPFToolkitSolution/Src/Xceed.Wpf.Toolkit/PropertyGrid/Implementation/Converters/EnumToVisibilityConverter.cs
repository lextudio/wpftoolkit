/*************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2018 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Converters
{
  /// <summary>
  /// Maps an enum value (matched by name against the ConverterParameter) to a Visibility,
  /// so the Properties and Events hosts of the <see cref="PropertyGrid"/> can switch on
  /// <c>ViewMode</c> directly.
  /// </summary>
  public sealed class EnumToVisibilityConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
    {
      var match = value != null && parameter != null && value.ToString() == parameter.ToString();
      return match ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
    {
      return Binding.DoNothing;
    }
  }
}
