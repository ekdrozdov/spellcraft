using UnityEngine;

public interface IMassProperty
{
  float Property { get; }
  string PropertyName { get; }
  void RelativeImpulse(float magnitude, Vector3 sourcePosition);
  void AbsoluteImpulse(float magnitude, Vector3 sourcePosition);
}
