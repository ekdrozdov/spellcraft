using UnityEngine;

public class Force : SimpleObservable<IObservableProperty>, IObservableProperty
{
  private Rigidbody _body;
  public string Name => "Force";
  public int Value { get; private set; } = 0;
  private Transform _transform;

  public Force(Rigidbody body, Transform transform, int value = 0)
  {
    _body = body;
    _transform = transform;
    Value = value;
  }

  public void Update(int delta)
  {
    var go = GameObject.Find("Caster");
    Vector3 d = (_transform.position - go.transform.position).normalized;
    var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
    _body.AddForce(d * delta, ForceMode.Impulse);
    Notify(this);
  }
}