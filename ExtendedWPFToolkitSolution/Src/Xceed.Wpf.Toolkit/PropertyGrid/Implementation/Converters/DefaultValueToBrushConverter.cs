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
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Converters
{
  /// <summary>
  /// Maps a property's default-value state to the override indicator's fill: transparent when
  /// the value is at its default, VS-blue when overridden. Implemented as a plain property
  /// binding rather than a Style DataTrigger because LibreWPF does not evaluate DataTriggers
  /// inside row templates reliably (measured: the indicator stayed transparent forever).
  /// </summary>
  public sealed class DefaultValueToBrushConverter : IValueConverter
  {
    static readonly Brush Transparent = Brushes.Transparent;
    static readonly Brush OverrideBrush = new SolidColorBrush( Color.FromRgb( 0x00, 0x78, 0xD4 ) );

    public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
    {
      if( value is bool && !( bool )value )
        return OverrideBrush;
      return Transparent;
    }

    public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
    {
      return Binding.DoNothing;
    }
  }
}
