public class Health : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Health";

  public int Value { get; private set; } = 1;

  private IntLimiter _limit;

  public Health(IntLimiter limit)
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

public class HealthPower : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Health";

  public int Value { get; private set; } = 1;

  private IntLimiter _limit;

  public HealthPower(IntLimiter limit)
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