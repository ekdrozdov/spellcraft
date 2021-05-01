using System.Collections.Generic;

public interface IPropertyContainer
{
  T AddProperty<T>(T property) where T : IObservableProperty;
  IEnumerable<IObservableProperty> ListProperties();
}