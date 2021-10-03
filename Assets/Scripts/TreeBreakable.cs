using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Fuel))]
[RequireComponent(typeof(Humidity))]
[RequireComponent(typeof(Temperature))]
public class TreeBreakable : MonoBehaviour, IBreakable
{
  public event IBreakable.BreakEventHandler BreakEvent;
  public GameObject StumpPrefab = null;
  public GameObject LogPrefab = null;

  public void Break(Vector3 impulse)
  {
    GameObject.Destroy(gameObject);
    if (LogPrefab != null)
    {
      var corpse = Instantiate(LogPrefab, transform.position, transform.rotation);
      corpse.GetComponent<Mass>()?.GravitationalInteraction(impulse.magnitude, -impulse);
      InheritComponents(corpse);
      BreakEvent?.Invoke(corpse);
      return;
    }
    BreakEvent?.Invoke(null);
  }

  private void InheritComponents(GameObject corpse)
  {
    corpse.GetComponent<Density>().Value = gameObject.GetComponent<Density>().Value;
    corpse.GetComponent<Fuel>().Value = gameObject.GetComponent<Fuel>().Value;
    corpse.GetComponent<Humidity>().Value = gameObject.GetComponent<Humidity>().Value;
    corpse.GetComponent<Temperature>().Value = gameObject.GetComponent<Temperature>().Value;
    corpse.GetComponent<Transform>().localScale = gameObject.GetComponent<Transform>().localScale;
  }
}