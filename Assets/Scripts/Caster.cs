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
          target = hitInfo.transform.gameObject;
          TargetUpdatedEvent?.Invoke(target);
        }
      }
    }
    if (Input.GetKey(KeyCode.Escape))
    {
      target = null;
      TargetUpdatedEvent?.Invoke(target);
    }
  }
}