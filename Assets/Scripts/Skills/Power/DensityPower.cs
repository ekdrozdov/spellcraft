using UnityEngine;

public class DensityPower : MonoBehaviour, IScalarPower
{
  [Range(0.01f, 100)]
  public float Power = 1;
  public float Value { get => Power; set => Power = value; }
  public string TargetPropertyName => "Density";

}