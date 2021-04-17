using System;

public interface IObservableObserver<T> : IObservable<T>, IObserver<T> { }

public abstract class SimpleObservableObserver<T> : SimpleObservable<T>, IObservableObserver<T>
{
  public void OnCompleted()
  {
    throw new NotImplementedException();
  }

  public void OnError(Exception error)
  {
    throw new NotImplementedException();
  }

  public abstract void OnNext(T value);
}