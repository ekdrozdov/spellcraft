using UnityEngine;

public class Volume : MonoBehaviour, IVectorProperty
{
  public delegate void ValueUpdateEventHandler(Vector3 value);
  public event ValueUpdateEventHandler ValueUpdateEvent;
  [ReadOnlyProperty]
  public Vector3 Value;
  public string PropertyName => "Volume";
  public Vector3 Property
  {
    get => transform.localScale;
    set
    {
      Value = value;
      transform.localScale = value;
      ValueUpdateEvent?.Invoke(Value);
    }
  }
}