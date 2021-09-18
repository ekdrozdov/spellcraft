using UnityEngine;

public class Density : MonoBehaviour
{
  [Range(0.1f, 5000)]
  public float Value = 1;

  void Start()
  {

  }

  void Update()
  {

  }

  public void Change(int delta)
  {
    Value += delta;
  }
}