using UnityEngine;

public class VolumePower : MonoBehaviour
{
  [Range(0.01f, 100)]
  public float Power = 1;
  public float Value => Power;
}