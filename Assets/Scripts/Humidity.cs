using UnityEngine;

public class Humidity : MonoBehaviour
{
  public float Value = 0;
  public float Capacity = 0;
  public float BaseBoilingRate = 10;
  public float HeatConvertionPercent = 0.2f;
  public static float BoilingTemperature = 100;
  public static float FreezingTemperature = 0;
  private TemperatureV2 _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
  }

  void Update()
  {
  }

  public float Consume(float incomingHeat)
  {
    if (Value == 0) return incomingHeat;
    if (incomingHeat <= 0)
    {
      var selfOverheat = _temperature.Value - BoilingTemperature;
      if (selfOverheat > 0)
      {
        Value -= BaseBoilingRate;
        Value -= selfOverheat * HeatConvertionPercent;
        Value = System.Math.Max(Value, 0);
      }
      return incomingHeat;
    }
    var overheat = _temperature.Value + incomingHeat - BoilingTemperature;
    if (overheat > 0)
    {
      Value -= overheat;
      Value -= overheat * HeatConvertionPercent;
      Value -= BaseBoilingRate;
      Value = System.Math.Max(Value, 0);
      return incomingHeat - overheat;
    }
    return incomingHeat;
  }
}