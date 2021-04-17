using UnityEngine;

public class Force : SimpleObservable<IObservableProperty>, IObservableProperty
{
  private Rigidbody _body;
  public string Name => "Force";
  public int Value { get; private set; } = 0;

  public Force(Rigidbody body, int value = 0)
  {
    _body = body;
    Value = value;
  }

  public void Update(int delta)
  {
    var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
    _body.AddForce(direction * delta, ForceMode.Impulse);
    Notify(this);
  }
}