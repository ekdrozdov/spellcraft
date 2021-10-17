using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Durability : MonoBehaviour, IScalarProperty
{
  public float Value = 1;
  public float Limit = 10;
  private Rigidbody _body;
  private IBreakable _breakable;
  public float Property { get => Value; set => Value = value; }
  public string PropertyName => "Durability";

  void Start()
  {
    _body = gameObject.GetComponent<Rigidbody>();
    _breakable = gameObject.GetComponent<IBreakable>();
  }

  void OnCollisionEnter(Collision collision)
  {
    Pressure(collision.impulse);
  }

  public void Pressure(Vector3 impulse)
  {
    Value -= System.Math.Abs(impulse.magnitude);
    if (Value <= 0)
    {
      _breakable.Break(impulse);
    }
  }
}
