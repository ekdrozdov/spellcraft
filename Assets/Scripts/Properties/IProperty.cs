using System;

public interface IObservableProperty : IObservable<IObservableProperty>
{
  string Name { get; }
  int Value { get; }
  void Update(int delta);
}
