using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Rigidbody))]
public class Mass : MonoBehaviour, IMassProperty
{
  public delegate void ImpulseEventHandler(Vector3 impulse);
  public event ImpulseEventHandler ImpulseEvent;
  public float ShadowValue;
  public float Property { get => _rigidBody.mass; }
  public string PropertyName => "Mass";
  private Density _density;
  private Rigidbody _rigidBody;


  void Awake()
  {
    _rigidBody = gameObject.GetComponent<Rigidbody>();

  }

  void Start()
  {
    _density = gameObject.GetComponent<Density>();
  }

  void Update()
  {
    // TODO: refactor to reactive paradigm.
    var size = transform.localScale;
    _rigidBody.mass = size.x * size.y * size.z * _density.Property;
    ShadowValue = _rigidBody.mass;
  }

  public void RelativeImpulse(float magnitude, Vector3 sourcePosition)
  {
    Vector3 direction = (transform.position - sourcePosition).normalized;
    _rigidBody.AddForce(direction * magnitude, ForceMode.Impulse);
    ImpulseEvent?.Invoke(direction * magnitude);
  }

  public void AbsoluteImpulse(float magnitude, Vector3 direction)
  {
    _rigidBody.AddForce(direction * magnitude, ForceMode.Impulse);
    ImpulseEvent?.Invoke(direction * magnitude);
  }
}