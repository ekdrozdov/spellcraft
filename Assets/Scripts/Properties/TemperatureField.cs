using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class TemperatureField : MonoBehaviour
{
  float[,] mesh2d;
  private const int size = 100;
  // Start is called before the first frame update
  void Start()
  {
    const float initVal = 10;
    mesh2d = new float[size, size];
    for (int m = 0; m < size; m++)
    {
      for (int n = 0; n < size; n++)
      {
        mesh2d[m, n] = initVal;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Notify(Vector3 position, float value)
  {
    if (position.x > size || position.z > size || position.x < 0 || position.z < 0)
    {
      return;
    }
    mesh2d[(int)position.x, (int)position.z] = value;
    var transformArray = FindObjectsOfType<GameObject>();
    foreach (var item in transformArray)
    {
      if (Vector3.Distance(item.GetComponent<Transform>().position, position) <= 4)
      {
        var c = item.GetComponent<SimplePropertyContainer>();
        if (c != null)
        {
          var t = c.getTemp();
          if (t != null)
          {
            var delta = value - t.Value;
            t.Update((int)delta);
          }
        }
      }
    }
  }
}
