using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Fuel))]
[RequireComponent(typeof(Humidity))]
[RequireComponent(typeof(Temperature))]
public class TreeBreakableInheritance : MonoBehaviour, IBreakableInheritance
{
  public void InheritComponents(GameObject corpse)
  {
    corpse.GetComponent<Density>().Value = gameObject.GetComponent<Density>().Value;
    corpse.GetComponent<Fuel>().Value = gameObject.GetComponent<Fuel>().Value;
    corpse.GetComponent<Humidity>().Value = gameObject.GetComponent<Humidity>().Value;
    corpse.GetComponent<Temperature>().Value = gameObject.GetComponent<Temperature>().Value;
    corpse.GetComponent<Transform>().localScale = gameObject.GetComponent<Transform>().localScale;
  }
}