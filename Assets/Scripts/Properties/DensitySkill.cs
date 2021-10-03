using UnityEngine;
using Unity​Engine.UIElements;

public class DensitySkill : MonoBehaviour, IRenderable
{
  public VisualTreeAsset Asset;
  public VisualElement Ui;
  [Range(0.01f, 100)]
  public float Power = 1;
  public string Name => "Density";
  private Density _targetDensity;

  void Start()
  {
    Ui = Asset.Instantiate();
    Ui.Q<Button>("prop-sub").clickable.clicked += Descrease;
    Ui.Q<Button>("prop-add").clickable.clicked += Increase;
    Ui.Q<Label>("property-name").text = "Value";

    Ui.Q<Button>("power-sub").clickable.clicked += DescreasePower;
    Ui.Q<Button>("power-add").clickable.clicked += IncreasePower;
    Ui.Q<Label>("power-value").text = Power.ToString();
  }

  void Update()
  {
    if (_targetDensity != null)
    {
      Ui.Q<Label>("power-value").text = Power.ToString();
      Ui.Q<Label>("property-value").text = _targetDensity.Value.ToString();
    }
  }

  public void DescreasePower()
  {
    Power--;
  }
  public void IncreasePower()
  {
    Power++;
  }

  public void Descrease()
  {
    _targetDensity.Value -= Power;
  }

  public void Increase()
  {
    _targetDensity.Value += Power;
  }

  public void Bind(Density targetDensity)
  {
    _targetDensity = targetDensity;

    Ui.Q<Label>("property-value").text = _targetDensity.Value.ToString();
  }

  public VisualElement Render()
  {
    return Ui;
  }
}