using UnityEngine;

[RequireComponent(typeof(Temperature))]
public class Humidity : MonoBehaviour
{
  public float Value = 0;
  public float Limit = 0;
  public float BaseBoilingRate = 10;
  public float HeatConvertionPercent = 0.2f;
  public static float BoilingTemperature = 100;
  public static float FreezingTemperature = 0;
  private Temperature _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<Temperature>();
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