using System.Collections.Generic;
using UnityEngine;

public class Temperature : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Temperature";

  public int Value { get; private set; } = 10;

  private IntLimiter _limit;
  private Transform _transform;

  public Temperature(IntLimiter limit, Transform transform)
  {
    _limit = limit;
    _transform = transform;
  }

  public void Update(int delta)
  {
    Value += delta;
    Value = _limit.Fit(Value);
    Notify(this);
    GameObject.Find("Plane").GetComponent<TemperatureField>().Notify(_transform.position, Value);
  }
}

public class TemperaturePower : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Temperature";

  public int Value { get; private set; } = 1;

  private IntLimiter _limit;

  public TemperaturePower(IntLimiter limit)
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