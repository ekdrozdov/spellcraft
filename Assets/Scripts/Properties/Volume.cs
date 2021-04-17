public class Volume : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Volume";

  public int Value { get; private set; } = 1;

  public void Update(int delta)
  {
    Value += delta;
    Notify(this);
  }
}
