using System;
using System.Collections.Generic;

public class SimpleObservable<T> : IObservable<T>
{
  private List<IObserver<T>> observers = new List<IObserver<T>>();

  public IDisposable Subscribe(IObserver<T> observer)
  {
    if (!observers.Contains(observer))
      observers.Add(observer);
    return new Unsubscriber<T>(observers, observer);
  }
  protected void Notify(T value)
  {
    foreach (var observer in observers)
    {
      observer.OnNext(value);
    }
  }
}
