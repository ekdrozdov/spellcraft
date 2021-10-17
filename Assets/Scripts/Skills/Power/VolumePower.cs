using UnityEngine;

public class VolumePower : MonoBehaviour, IVectorPower
{
  [Range(0.01f, 100)]
  public Vector3 Power = Vector3.one;
  public string TargetPropertyName => "Volume";
  public Vector3 Value { get => Power; set => Power = value; }
}