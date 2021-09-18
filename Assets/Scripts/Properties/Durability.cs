using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Durability : MonoBehaviour
{
  [Range(0, 10000)]
  public float Value = 1;
  public GameObject BrokenPrefab;
  private Rigidbody _body;

  void Start()
  {
    _body = gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
    if (Value <= 0)
    {
      GameObject.Destroy(this.gameObject);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    Value -= collision.relativeVelocity.magnitude;
  }

  public void Pressure(int value, Vector3 sourcePosition)
  {
    Value -= value;
    if (Value <= 0)
    {
      Break();
    }
  }

  private void Break()
  {
    // TODO: inherit velocity and other props.
    // Vector3 d = (transform.position - sourcePosition).normalized;
    // var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
    GameObject.Destroy(gameObject);
    Instantiate(BrokenPrefab, transform.position, transform.rotation);
  }
}
