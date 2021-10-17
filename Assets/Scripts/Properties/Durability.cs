using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Durability : MonoBehaviour, IScalarProperty
{
  public float SValue = 1;
  public float Limit = 10;
  private Rigidbody _body;
  private IBreakable _breakable;
  public float Value { get => SValue; set => SValue = value; }
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
    SValue -= System.Math.Abs(impulse.magnitude);
    if (SValue <= 0)
    {
      _breakable.Break(impulse);
    }
  }
}
