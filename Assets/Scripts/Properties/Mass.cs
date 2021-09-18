using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Rigidbody))]
public class Mass : MonoBehaviour
{
  public float DebugPushForce = 10;
  private Density _density;
  private Rigidbody _rigidBody;

  void Start()
  {
    _density = gameObject.GetComponent<Density>();
    _rigidBody = gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
    // TODO: refactor to reactive paradigm.
    var size = transform.localScale;
    _rigidBody.mass = size.x * size.y * size.z * _density.Value;
  }

  [ContextMenu("PushZ")]
  void PushZ()
  {
    GravitationalInteraction(DebugPushForce, transform.position + new Vector3(0, 0, -1));
  }

  public void GravitationalInteraction(float value, Vector3 sourcePosition)
  {
    Vector3 direction = (transform.position - sourcePosition).normalized;
    // var direction = _rigidBody.velocity.normalized != Vector3.zero ? _rigidBody.velocity.normalized : new Vector3(1, 0, 0);
    _rigidBody.AddForce(direction * value, ForceMode.Impulse);
  }
}