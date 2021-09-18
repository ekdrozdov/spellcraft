using UnityEngine;

[RequireComponent(typeof(Volume))]
[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Rigidbody))]
public class Mass : MonoBehaviour
{
  public float Value;
  private Volume _volume;
  private Density _density;
  private Rigidbody _rigidBody;

  void Start()
  {
    _volume = gameObject.GetComponent<Volume>();
    _density = gameObject.GetComponent<Density>();
    _rigidBody = gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
    // TODO: refactor to reactive paradigm.
    Value = _volume.Value * _density.Value;
    _rigidBody.mass = Value;
  }

  public void GravitationalInteraction(float value, Vector3 sourcePosition)
  {
    Vector3 delta = (transform.position - sourcePosition).normalized;
    var direction = _rigidBody.velocity.normalized != Vector3.zero ? _rigidBody.velocity.normalized : new Vector3(1, 0, 0);
    _rigidBody.AddForce(delta * value, ForceMode.Impulse);
    Value = value;
  }
}