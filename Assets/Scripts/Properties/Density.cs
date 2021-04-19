public class Density : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Density";

  public int Value { get; private set; } = 1;

  private IntLimiter _limit;

  public Density(IntLimiter limit)
  {
    _limit = limit;
  }

  public void Update(int delta)
  {
    Value += delta;
    Value = _limit.Fit(Value);
    Notify(this);
  }
}
