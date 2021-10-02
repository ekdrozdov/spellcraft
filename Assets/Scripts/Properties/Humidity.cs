using UnityEngine;

[RequireComponent(typeof(Temperature))]
public class Humidity : MonoBehaviour
{
  public float Value = 0;
  [ReadOnlyProperty]
  public float Limit = 0;
  public float BaseBoilingRate = 10;
  [Range(0, 1)]
  public float HeatConvertionPercent = 0.2f;
  [Range(0, 1)]
  public float BodyHumidityPercent = 0.8f;
  public static float BoilingTemperature = 100;
  public static float FreezingTemperature = 0;
  private Temperature _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<Temperature>();
    Limit = gameObject.GetComponent<Density>().Value * transform.localScale.x * transform.localScale.y * transform.localScale.z * BodyHumidityPercent;
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