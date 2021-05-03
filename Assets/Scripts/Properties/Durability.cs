using UnityEngine;

public class Durability : SimpleObservableObserver<IObservableProperty>, IObservableProperty
{
  public string Name => "Durability";

  public int Value { get; private set; } = 1;

  private int _durability;
  private Transform _transform;
  private Rigidbody _body;
  private GameObject _gameObject;

  public Durability(int durability, Force force, GameObject gameObject, Transform transform, Rigidbody body)
  {
    _durability = durability;
    _gameObject = gameObject;
    _transform = transform;
    _body = body;
    force.Subscribe(this);
  }

  public void Update(int delta)
  {
    if (delta >= _durability)
    {
      var go = GameObject.Find("Caster");
      Vector3 d = (_transform.position - go.transform.position).normalized;
      var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
      _gameObject.GetComponent<TreeUnit>().Break(d * delta);
    }
    Value += delta;
    Notify(this);
  }

  public override void OnNext(IObservableProperty value)
  {
    if (value.Value > _durability)
    {
      var go = GameObject.Find("Caster");
      Vector3 d = (_transform.position - go.transform.position).normalized;
      var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
      _gameObject.GetComponent<TreeUnit>().Break(d * value.Value);
    }
  }
}
