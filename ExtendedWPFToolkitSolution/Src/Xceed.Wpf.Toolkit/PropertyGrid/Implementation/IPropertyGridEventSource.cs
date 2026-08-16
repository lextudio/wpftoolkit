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
  /// Optional contract a <see cref="PropertyGrid.SelectedObject"/> can implement to back the
  /// Events view with real handler storage. A XAML element adapter, for instance, stores the
  /// handler name in the element's event attribute (e.g. <c>Click="Button_Click"</c>), so the
  /// grid reads and writes that attribute through this interface instead of keeping handler
  /// names in-memory only.
  /// </summary>
  public interface IPropertyGridEventSource
  {
    string GetEventHandler(string eventName);

    void SetEventHandler(string eventName, string handlerName);
  }
}
