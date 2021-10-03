using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class Durability : MonoBehaviour
{

  public delegate void BreakEventHandler(GameObject corpse);
  public event BreakEventHandler BreakEvent;
  public float Value = 1;
  public float Limit = 10;
  public GameObject BrokenPrefab = null;
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
    GameObject.Destroy(gameObject);
    if (BrokenPrefab != null)
    {
      var corpse = Instantiate(BrokenPrefab, transform.position, transform.rotation);
      corpse.GetComponent<Mass>()?.GravitationalInteraction(impulse.magnitude, -impulse);
      gameObject.GetComponent<IBreakableInheritance>().InheritComponents(corpse);
      BreakEvent?.Invoke(corpse);
      return;
    }
    BreakEvent?.Invoke(null);
  }
}
