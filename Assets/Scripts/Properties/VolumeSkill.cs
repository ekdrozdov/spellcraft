using UnityEngine;
using Unity​Engine.UIElements;

public class VolumeSkill : MonoBehaviour, IRenderable
{
  public VisualTreeAsset Asset;
  public VisualElement Ui;
  [Range(0.01f, 100)]
  public float Power = 1;
  public string Name => "Volume";
  private Rigidbody _targetDurability;

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
    // _targetDurability.Value += Power;
  }

  public void Descrease()
  {
    // _targetDurability.Value -= Power;
  }

  public void Bind(Rigidbody targetDurability)
  {
    _targetDurability = targetDurability;

    Ui.Q<Label>("property-value").text = "no-op";
  }
  public VisualElement Render()
  {
    return Ui;
  }
}