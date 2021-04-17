using System;

public abstract class SimpleObserver<T> : IObserver<T>
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


public class NotifierObserver<T> : SimpleObserver<T>
{
  private Action notify;
  public NotifierObserver(Action action)
  {
    notify = action;
  }
  public override void OnNext(T value)
  {
    notify();
  }
}