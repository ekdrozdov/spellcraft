using UnityEngine;

public interface IVectorProperty
{
  Vector3 Property { get; set; }
  string PropertyName { get; }
}
