/*************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2018 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

namespace Xceed.Wpf.Toolkit.PropertyGrid
{
  /// <summary>
  /// Optional contract an <see cref="System.ComponentModel.EventDescriptor"/> can implement to
  /// report its delegate type's standard display name. An adapter whose events have no live
  /// CLR type (e.g. a XAML element proxy) can then show "RoutedEventHandler" for Click instead
  /// of a placeholder like "EventHandler" - or the raw wrapper type.
  /// </summary>
  public interface IPropertyGridEventTypeName
  {
    string HandlerTypeName { get; }
  }
}
