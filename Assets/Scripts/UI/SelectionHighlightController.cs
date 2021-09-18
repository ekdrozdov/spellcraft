using UnityEngine;

public class SelectionHighlightController : MonoBehaviour
{
  public Color startColor;
  public Color hoverColor = Color.blue;
  bool mouseOver = false;

  void Start()
  {
    startColor = GetComponent<Renderer>().material.color;
  }

  void Update()
  {

  }

  private void OnMouseEnter()
  {
    mouseOver = true;
    GetComponent<Renderer>().material.color = hoverColor;
  }


  private void OnMouseExit()

  {
    mouseOver = false;
    GetComponent<Renderer>().material.color = startColor;
  }

}