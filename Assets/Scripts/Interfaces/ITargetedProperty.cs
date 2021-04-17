public interface ITargetedProperty
{
  IObservableProperty CasterProp { get; }
  IObservableProperty TargetProp { get; }
}

public class SimpleTargetedProperty : ITargetedProperty
{
  public IObservableProperty CasterProp { get; set; }
  public IObservableProperty TargetProp { get; set; }
  public SimpleTargetedProperty(IObservableProperty casterProp, IObservableProperty targetProp)
  {
    CasterProp = casterProp;
    TargetProp = targetProp;
  }
}

public class EmptyTargetedProperty : ITargetedProperty
{
  public IObservableProperty CasterProp { get; } = new EmptyProperty();

  public IObservableProperty TargetProp { get; } = new EmptyProperty();
}