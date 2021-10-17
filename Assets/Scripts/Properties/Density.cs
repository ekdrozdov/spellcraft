using UnityEngine;

public class Density : MonoBehaviour, IScalarProperty
{
  [Range(0.01f, 5000)]
  public float Value;
  public string PropertyName => "Density";
  public float Property { get => Value; set => Value = value; }

  public void Change(int delta)
  {
    Value += delta;
  }
}