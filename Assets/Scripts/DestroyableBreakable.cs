using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Fuel))]
[RequireComponent(typeof(Humidity))]
[RequireComponent(typeof(Temperature))]
public class DestroyableBreakable : MonoBehaviour, IBreakable
{
  public event IBreakable.BreakEventHandler BreakEvent;

  public void Break(Vector3 impulse)
  {
    GameObject.Destroy(gameObject);
    BreakEvent?.Invoke(null);
  }
}