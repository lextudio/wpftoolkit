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
  /// The view mode of the <see cref="PropertyGrid"/>: the classic Properties list, or a
  /// VS-style Events list where each row edits the handler name of a design-time event.
  /// </summary>
  public enum PropertyGridMode
  {
    Properties,
    Events
  }
}
