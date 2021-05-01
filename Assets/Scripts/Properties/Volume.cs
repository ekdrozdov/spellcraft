using UnityEngine;

public class Volume : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Volume";

  public int Value { get; private set; } = 1;

  private Transform _transform;

  private BoxCollider _boxCollider;

  private IntLimiter _limit;

  public Volume(Transform transform, BoxCollider boxCollider, IntLimiter limit, int Value = 1)
  {
    _transform = transform;
    _boxCollider = boxCollider;
    var size = new Vector3(Value, Value, Value);
    _transform.localScale = size;
    _boxCollider.size = size;
    _limit = limit;
  }

  public void Update(int delta)
  {
    Value += delta;
    Value = _limit.Fit(Value);
    var size = new Vector3(Value, Value, Value);
    _transform.localScale = size;
    Notify(this);
  }
}

public class VolumePower : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Volume";

  public int Value { get; private set; } = 1;

  private IntLimiter _limit;

  public VolumePower(IntLimiter limit, int Value = 1)
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