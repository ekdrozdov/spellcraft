using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Rigidbody))]
public class Mass : MonoBehaviour
{
  public delegate void ImpulseEventHandler(Vector3 impulse);
  public event ImpulseEventHandler ImpulseEvent;
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
    _rigidBody.mass = size.x * size.y * size.z * _density.Value;
  }

  public void GravitationalInteraction(float magnitude, Vector3 sourcePosition)
  {
    Vector3 direction = (transform.position - sourcePosition).normalized;
    _rigidBody.AddForce(direction * magnitude, ForceMode.Impulse);
    ImpulseEvent?.Invoke(direction * magnitude);
  }
}