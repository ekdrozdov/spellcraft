using UnityEngine;

public class Density : MonoBehaviour, IScalarProperty
{
  [Range(0.01f, 5000)]
  public float SValue;
  public string PropertyName => "Density";
  public float Value { get => SValue; set => SValue = value; }

  public void Change(int delta)
  {
    SValue += delta;
  }
}