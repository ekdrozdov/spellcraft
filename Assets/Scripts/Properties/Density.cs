using UnityEngine;

public class Density : MonoBehaviour, IScalarProperty
{
  public delegate void ValueUpdateEventHandler(float value);
  public event ValueUpdateEventHandler ValueUpdateEvent;
  [Range(0.01f, 5000)]
  public float Value;
  public string PropertyName => "Density";
  public float Property
  {
    get => Value;
    set
    {
      Value = value;
      ValueUpdateEvent?.Invoke(Value);
    }
  }
}