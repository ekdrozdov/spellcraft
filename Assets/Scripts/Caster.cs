using UnityEngine;

public class Caster : MonoBehaviour
{
  public GameObject target;

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
          // _ss.Target(hitInfo.transform.gameObject.GetComponent<SimplePropertyContainer>());
          // TargetNameLabel.text = hitInfo.transform.gameObject.GetComponent<SimplePropertyContainer>().name;
        }
      }
    }
    if (Input.GetKey(KeyCode.Escape))
    {
      // _ss.ClearTarget();
      // TargetNameLabel.text = "No unit selected";
    }
  }
}