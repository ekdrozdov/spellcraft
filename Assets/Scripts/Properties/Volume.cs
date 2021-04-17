using UnityEngine;

public class Volume : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "Volume";

  public int Value { get; private set; } = 1;

  private Transform _transform;

  public Volume(Transform transform, int Value = 1)
  {
    _transform = transform;
    _transform.localScale = new Vector3(Value, Value, Value);
  }

  public void Update(int delta)
  {
    Value += delta;
    _transform.localScale = new Vector3(Value, Value, Value);
    Notify(this);
  }
}
