using UnityEngine;

public class MassPower : MonoBehaviour
{
  [Range(0.01f, 100)]
  public float Power = 1;
  public float Value => Power;
}