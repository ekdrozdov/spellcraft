using UnityEngine;

[RequireComponent(typeof(Temperature))]
public class Humidity : MonoBehaviour, IScalarProperty
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
  public float Property { get => Value; set => Value = value; }
  public string PropertyName => "Humidity";
  private Temperature _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<Temperature>();
    Limit = gameObject.GetComponent<Density>().Property * transform.localScale.x * transform.localScale.y * transform.localScale.z * BodyHumidityPercent;
  }

  public float Consume(float incomingHeat)
  {
    if (Property == 0) return incomingHeat;
    if (incomingHeat <= 0)
    {
      var selfOverheat = _temperature.Property - BoilingTemperature;
      if (selfOverheat > 0)
      {
        Property -= BaseBoilingRate;
        Property -= selfOverheat * HeatConvertionPercent;
        Property = System.Math.Max(Property, 0);
      }
      return incomingHeat;
    }
    var overheat = _temperature.Property + incomingHeat - BoilingTemperature;
    if (overheat > 0)
    {
      Property -= overheat;
      Property -= overheat * HeatConvertionPercent;
      Property -= BaseBoilingRate;
      Property = System.Math.Max(Property, 0);
      return incomingHeat - overheat;
    }
    return incomingHeat;
  }
}