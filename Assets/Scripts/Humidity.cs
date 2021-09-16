using UnityEngine;

public class Humidity : MonoBehaviour
{
  public int Value = 0;
  public int Capacity = 0;
  public int SelfBoilingRate = 10;
  public static int BoilingTemperature = 100;
  public static int FreezingTemperature = 0;
  private TemperatureV2 _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
  }

  void Update()
  {
  }

  public int Consume(int incomingHeat)
  {
    if (Value == 0) return incomingHeat;
    if (incomingHeat <= 0)
    {
      var selfOverheat = _temperature.Value - BoilingTemperature;
      if (selfOverheat > 0)
      {
        Value -= SelfBoilingRate;
        Value = System.Math.Max(Value, 0);
      }
      return incomingHeat;
    }
    var overheat = _temperature.Value + incomingHeat - BoilingTemperature;
    if (overheat > 0)
    {
      Value -= overheat;
      Value -= SelfBoilingRate;
      Value = System.Math.Max(Value, 0);
      return incomingHeat - overheat;
    }
    return incomingHeat;
  }
}