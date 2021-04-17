using UnityEngine;

public class SimpleClickSelector : MonoBehaviour
{

  private void Start()
  {
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
      if (hit)
      {
        if (hitInfo.transform.gameObject.tag == "Selectable")
        {
        }
      }
    }
  }
}