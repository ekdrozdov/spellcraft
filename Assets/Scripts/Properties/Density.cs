public class Density : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Density";

  public int Value { get; private set; } = 1;

  public void Update(int delta)
  {
    Value += delta;
    Notify(this);
  }
}
