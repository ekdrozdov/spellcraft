using UnityEngine;
using Unity​Engine.UIElements;

public class MassSkill : MonoBehaviour
{
  public VisualTreeAsset uiAsset;
  public float power = 1;
  public GameObject _target;
  private Mass _targetMass;

  void Start()
  {
    _targetMass = _target.GetComponent<Mass>();
  }

  VisualElement GetVisualElement(UIDocument uIDocument)
  {
    VisualElement ui = uiAsset.Instantiate();
    Button push = new Button(Push);
    push.text = "Push";
    Button pull = new Button(Pull);
    pull.text = "Pull";
    return ui;
  }

  private void Push()
  {
    _targetMass.GravitationalInteraction(power, transform.position);
  }

  private void Pull()
  {
    _targetMass.GravitationalInteraction(-power, transform.position);
  }
}