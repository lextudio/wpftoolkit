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
using System.Runtime.CompilerServices;

namespace Xceed.Wpf.Toolkit.PropertyGrid
{
  /// <summary>
  /// A single row of the <see cref="PropertyGrid"/>'s Events view. <see cref="HandlerName"/>
  /// is the method-name string bound into the event hook; when the selected object implements
  /// <see cref="IPropertyGridEventSource"/> the write is forwarded to it (e.g. into a XAML
  /// event attribute) instead of staying in-memory. Validation follows the VS convention:
  /// a non-empty handler must be a valid identifier.
  /// </summary>
  public sealed class EventItem : INotifyPropertyChanged
  {
    string _handlerName = string.Empty;
    string _error;

    public EventItem(PropertyGridEventDescriptor descriptor)
    {
      if (descriptor == null) throw new ArgumentNullException("descriptor");
      Descriptor = descriptor;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public PropertyGridEventDescriptor Descriptor { get; }

    /// <summary>Optional backing store for the handler name (see <see cref="IPropertyGridEventSource"/>).</summary>
    public IPropertyGridEventSource Source { get; set; }

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

    public string HandlerTypeName
    {
      get { return Descriptor.HandlerTypeName; }
    }

    public bool IsDefaultValue
    {
      get { return string.IsNullOrWhiteSpace(HandlerName); }
    }

    public string HandlerName
    {
      get { return _handlerName; }
      set
      {
        var handlerName = value ?? string.Empty;
        if (_handlerName == handlerName)
          return;

        _handlerName = handlerName;
        Error = IsValidHandlerName(handlerName) ? null : "Handler name must be a valid C# identifier.";
        if (Source != null && Error == null)
          Source.SetEventHandler(Name, handlerName);
        OnPropertyChanged();
        OnPropertyChanged("IsDefaultValue");
      }
    }

    public string Error
    {
      get { return _error; }
      private set
      {
        if (_error == value)
          return;
        _error = value;
        OnPropertyChanged();
        OnPropertyChanged("HasError");
      }
    }

    public bool HasError
    {
      get { return !string.IsNullOrEmpty(Error); }
    }

    /// <summary>
    /// Initializes the handler name without forwarding the write back to the source
    /// (the value was read from the source, so writing it again would be a spurious edit).
    /// </summary>
    internal void LoadHandlerName( string handlerName )
    {
      _handlerName = handlerName ?? string.Empty;
      Error = null;
      OnPropertyChanged();
      OnPropertyChanged( "IsDefaultValue" );
    }

    static bool IsValidHandlerName(string value)
    {
      if (string.IsNullOrWhiteSpace(value))
        return true;

      if (!(value[0] == '_' || char.IsLetter(value[0])))
        return false;

      for (var i = 1; i < value.Length; i++)
      {
        if (!(value[i] == '_' || char.IsLetterOrDigit(value[i])))
          return false;
      }

      return true;
    }

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null)
        handler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
