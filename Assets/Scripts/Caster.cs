using UnityEngine;

public class Caster : MonoBehaviour
{
  public GameObject target = null;
  public delegate void TargetUpdatedEventHandler(GameObject target);
  public event TargetUpdatedEventHandler TargetUpdatedEvent;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
      if (hit)
      {
        if (hitInfo.transform.gameObject.GetComponent<SelectionHighlightController>() != null)
        {
          StopListeningTargetEvents();
          target = hitInfo.transform.gameObject;
          ListenTargetEvents();
          TargetUpdatedEvent?.Invoke(target);
        }
      }
    }
    if (Input.GetKey(KeyCode.Escape))
    {
      StopListeningTargetEvents();
      target = null;
      TargetUpdatedEvent?.Invoke(target);
    }
  }

  private void BreakEventHandler(GameObject corpse)
  {
    StopListeningTargetEvents();
    target = corpse;
    ListenTargetEvents();
    TargetUpdatedEvent?.Invoke(target);
  }

  private void ListenTargetEvents()
  {
    if (target != null)
    {
      var breakable = target.GetComponent<IBreakable>();
      if (breakable != null)
      {
        breakable.BreakEvent += BreakEventHandler;
      }
    }
  }

  private void StopListeningTargetEvents()
  {
    if (target != null)
    {
      var breakable = target.GetComponent<IBreakable>();
      if (breakable != null)
      {
        breakable.BreakEvent -= BreakEventHandler;
      }
    }
  }
}