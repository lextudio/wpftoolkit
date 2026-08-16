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
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Converters
{
  /// <summary>
  /// Two-way converter between an enum value and a bool, using the ConverterParameter as the
  /// matched enum member name - the standard way to drive a RadioButton group from an enum
  /// DependencyProperty (e.g. the PropertyGrid's ViewMode).
  /// </summary>
  public sealed class EnumToBoolConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
    {
      if( value == null || parameter == null )
        return false;

      var parameterName = parameter.ToString();
      return value.ToString() == parameterName;
    }

    public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
    {
      if( !( value is bool ) || !( bool )value || parameter == null )
        return Binding.DoNothing;

      return Enum.Parse( targetType, parameter.ToString() );
    }
  }
}
