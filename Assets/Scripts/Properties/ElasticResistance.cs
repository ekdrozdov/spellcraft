using UnityEngine;

[RequireComponent(typeof(Durability))]
[RequireComponent(typeof(Mass))]
public class ElasticResistance : MonoBehaviour
{
  private Durability _durability;
  private Mass _mass;

  void Start()
  {
    _durability = gameObject.GetComponent<Durability>();
    _mass = gameObject.GetComponent<Mass>();
    _mass.ImpulseEvent += ImpulseEventHandler;
  }

  private void ImpulseEventHandler(Vector3 impulse)
  {
    _durability.Pressure(impulse);
  }
}
