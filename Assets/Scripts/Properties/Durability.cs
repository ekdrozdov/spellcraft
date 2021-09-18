using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Durability : MonoBehaviour
{
  [Range(0, 10)]
  public float Value = 1;
  private Rigidbody _body;

  void Start()
  {
    _body = gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
    if (Value <= 0)
    {
      // Vector3 d = (transform.position - sourcePosition).normalized;
      // var direction = _body.velocity.normalized != Vector3.zero ? _body.velocity.normalized : new Vector3(1, 0, 0);
      GameObject.Destroy(this.gameObject);
    }
  }

  public void Pressure(int value, Vector3 sourcePosition)
  {
    Value -= value;
  }
}
