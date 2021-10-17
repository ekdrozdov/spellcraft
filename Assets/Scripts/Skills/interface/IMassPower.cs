using UnityEngine;

public interface IMassPower
{
  float Value { get; set; }
  string TargetPropertyName { get; }
  Vector3 position { get; }
}
