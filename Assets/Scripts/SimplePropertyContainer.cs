using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimplePropertyContainer : MonoBehaviour, IPropertyContainer
{
  private Dictionary<Type, IObservableProperty> _properties = new Dictionary<Type, IObservableProperty>();
  public T AddProperty<T>(T property) where T : IObservableProperty
  {
    var type = property.GetType();
    if (_properties.ContainsKey(type))
    {
      throw new ArgumentException();
    }
    _properties.Add(type, property);
    return property;
  }

  public IEnumerable<IObservableProperty> ListProperties()
  {
    return _properties.Select(kvp => kvp.Value);
  }
}