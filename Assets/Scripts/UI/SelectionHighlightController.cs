using UnityEngine;

public class SelectionHighlightController : MonoBehaviour
{
  public Color startColor;
  public Color hoverColor = Color.blue;

  void Start()
  {
    startColor = GetComponent<Renderer>().material.color;
  }

  void Update()
  {

  }

  private void OnMouseEnter()
  {
    GetComponent<Renderer>().material.color = hoverColor;
  }


  private void OnMouseExit()

  {
    GetComponent<Renderer>().material.color = startColor;
  }

}