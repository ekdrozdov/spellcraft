using UnityEngine;

public class Volume : MonoBehaviour
{
  [Range(0.1f, 10)]
  public float Value = 1;

  void Start()
  {
  }

  void Update()
  {
    transform.localScale = new Vector3(Value, Value, Value);
  }

  public void Change(int delta)
  {
    Value += delta;
  }
}