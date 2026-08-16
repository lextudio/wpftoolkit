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
using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.PropertyGrid
{
  /// <summary>
  /// A design-time event surfaced by the <see cref="PropertyGrid"/>'s Events view. Wraps the
  /// <see cref="EventDescriptor"/> the framework reports for the selected object, so
  /// ICustomTypeDescriptor-backed adapters (e.g. a XAML element proxy that has no real CLR
  /// event wiring) can supply their events through <c>TypeDescriptor.GetEvents</c>.
  /// </summary>
  public sealed class PropertyGridEventDescriptor
  {
    public PropertyGridEventDescriptor(EventDescriptor descriptor)
    {
      if (descriptor == null) throw new ArgumentNullException("descriptor");
      Descriptor = descriptor;
    }

    public EventDescriptor Descriptor { get; }

    public string Name
    {
      get { return Descriptor.Name; }
    }

    public string DisplayName
    {
      get { return Descriptor.DisplayName; }
    }

    public string Description
    {
      get { return Descriptor.Description; }
    }

    public Type HandlerType
    {
      get { return Descriptor.EventType; }
    }

    /// <summary>Display name of the event's delegate type - the wrapped descriptor's own
    /// reporting when it implements <see cref="IPropertyGridEventTypeName"/>, otherwise the
    /// CLR type name.</summary>
    public string HandlerTypeName
    {
      get
      {
        var custom = Descriptor as IPropertyGridEventTypeName;
        if( custom != null )
          return custom.HandlerTypeName;
        return string.IsNullOrEmpty( Descriptor.EventType?.Name ) ? string.Empty : Descriptor.EventType.Name;
      }
    }
  }
}
