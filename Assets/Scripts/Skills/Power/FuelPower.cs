using UnityEngine;
using Unity​Engine.UIElements;

public class FuelPower : MonoBehaviour, IScalarPower
{
  public VisualTreeAsset Asset;
  [Range(0.01f, 100)]
  public float Power = 1;
  public float Value { get => Power; set => Power = value; }
  public string TargetPropertyName => "Fuel";
}