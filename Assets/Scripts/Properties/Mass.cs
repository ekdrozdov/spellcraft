using UnityEngine;

public class Mass : SimpleObservableObserver<IObservableProperty>, IObservableProperty
{
  private Rigidbody _body;
  public string Name => "Mass";
  public int Value { get; private set; }

  private Volume _volume;
  private Density _density;

  public Mass(Volume volume, Density density, Rigidbody body)
  {
    _body = body;
    _volume = volume;
    _density = density;
    _volume.Subscribe(this);
    _density.Subscribe(this);
    OnNext(this);
  }

  public override void OnNext(IObservableProperty value)
  {
    Value = _volume.Value * _density.Value;
    _body.mass = Value;
  }

  public void Update(int delta)
  {
    Notify(this);
  }
}