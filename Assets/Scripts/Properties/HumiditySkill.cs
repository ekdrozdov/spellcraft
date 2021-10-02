using UnityEngine;
using Unity​Engine.UIElements;

public class HumiditySkill : MonoBehaviour, IRenderable
{
  public VisualTreeAsset Asset;
  public VisualElement Ui;
  [Range(0.01f, 100)]
  public float Power = 1;
  public string Name => "Humidity";
  private Humidity _targetDurability;

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
    if (_targetDurability != null)
    {
      Ui.Q<Label>("power-value").text = Power.ToString();
      Ui.Q<Label>("property-value").text = _targetDurability.Value.ToString();
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

  public void Increase()
  {
    _targetDurability.Value += Power;
  }

  public void Descrease()
  {
    _targetDurability.Value -= Power;
  }

  public void Bind(Humidity targetDurability)
  {
    _targetDurability = targetDurability;

    Ui.Q<Label>("property-value").text = _targetDurability.Value.ToString();
  }
  public VisualElement Render()
  {
    return Ui;
  }
}