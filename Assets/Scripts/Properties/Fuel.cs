using UnityEngine;

[RequireComponent(typeof(Temperature))]
[RequireComponent(typeof(Density))]
public class Fuel : MonoBehaviour, IScalarProperty
{
  [Range(0, 20000)]
  public float Value = 10;
  [ReadOnlyProperty]
  public float Limit = 100;
  public float IgnitionTemperature = 200;
  public float ExtinguishTemperature = 100;
  [ReadOnlyProperty]
  public bool IsBurning = false;
  public float BaseBurningRate = 20;
  [Range(0, 1)]
  public float HeatConvertionPercent = 0.05f;
  public GameObject BurnOutPrefab;
  public float Property { get => Value; set => Value = value; }
  public string PropertyName => "Fuel";
  private Temperature _temperature;
  private Humidity _humidity;

  void Start()
  {
    _temperature = gameObject.GetComponent<Temperature>();
    _humidity = gameObject.GetComponent<Humidity>();
    Limit = gameObject.GetComponent<Density>().Property * transform.localScale.x * transform.localScale.y * transform.localScale.z;
  }

  public float Consume(float incomingHeat)
  {
    if (_humidity != null && _humidity.Property > 0) return incomingHeat;
    var overheat = _temperature.Property - IgnitionTemperature;
    if (overheat >= 0)
    {
      IsBurning = true;
    }
    else
    {
      if (_temperature.Property <= ExtinguishTemperature)
      {
        IsBurning = false;
      }
    }
    if (Property == 0)
    {
      BurnOut();
      return 0;
    }
    if (IsBurning)
    {
      var fuelLevel = Property;
      Property -= BaseBurningRate;
      Property -= overheat * HeatConvertionPercent;
      Property = System.Math.Max(Property, 0);
      var delta = fuelLevel - Property;
      if (incomingHeat < 0)
      {
        return 0;
      }
    }
    return incomingHeat;
  }

  private void BurnOut()
  {
    GameObject.Destroy(gameObject);
    Instantiate(BurnOutPrefab, transform.position, transform.rotation);
  }
}