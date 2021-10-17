using UnityEngine;

public class MassPower : MonoBehaviour, IMassPower
{
  [Range(0.01f, 100)]
  public float Power = 1;
  public float Value { get => Power; set => Power = value; }
  public string TargetPropertyName => "Mass";
  public Vector3 position => transform.position;
}