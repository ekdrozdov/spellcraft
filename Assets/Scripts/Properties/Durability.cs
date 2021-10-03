using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Durability : MonoBehaviour
{
  public float Value = 1;
  public float Limit = 10;
  public GameObject BrokenPrefab;
  private Rigidbody _body;

  void Start()
  {
    _body = gameObject.GetComponent<Rigidbody>();
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
      Break(impulse);
    }
  }

  private void Break(Vector3 impulse)
  {
    // TODO: inherit velocity and other props.
    // Vector3 d = (transform.position - sourcePosition).normalized;
    // var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
    GameObject.Destroy(gameObject);
    var corpse = Instantiate(BrokenPrefab, transform.position, transform.rotation);
    corpse.GetComponent<Mass>()?.GravitationalInteraction(impulse.magnitude, -impulse);
  }
}
