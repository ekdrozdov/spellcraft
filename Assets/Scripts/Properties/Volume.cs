using UnityEngine;

public class Volume : MonoBehaviour, IVectorProperty
{
  [ReadOnlyProperty]
  public Vector3 Value;
  public string PropertyName => "Volume";
  public Vector3 Property { get => transform.localScale; set { Value = value; transform.localScale = value; } }
}