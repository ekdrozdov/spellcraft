using UnityEngine;

public class Burnable : MonoBehaviour
{
  public float IgnitionTemperature = 200;
  public float ExtinguishTemperature = 100;
  public bool IsBurning = false;
  public float Fuel = 100;
  public float BaseBurningRate = 20;
  public float HeatConvertionPercent = 0.05f;
  private TemperatureV2 _temperature;
  private Humidity _humidity;
  public GameObject BurnOutPrefab;

  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
    _humidity = gameObject.GetComponent<Humidity>();
  }

  void Update()
  {

  }

  public float Consume(float incomingHeat)
  {
    if (_humidity != null && _humidity.Value > 0) return incomingHeat;
    var overheat = _temperature.Value - IgnitionTemperature;
    if (overheat >= 0)
    {
      IsBurning = true;
    }
    else
    {
      if (_temperature.Value <= ExtinguishTemperature)
      {
        IsBurning = false;
      }
    }
    if (Fuel == 0)
    {
      Transform lastTransform = this.transform;
      GameObject.Destroy(this.gameObject);
      Instantiate(BurnOutPrefab, lastTransform.position, lastTransform.rotation);
      return 0;
    }
    if (IsBurning)
    {
      var fuelLevel = Fuel;
      Fuel -= BaseBurningRate;
      Fuel -= overheat * HeatConvertionPercent;
      Fuel = System.Math.Max(Fuel, 0);
      var delta = fuelLevel - Fuel;
      if (incomingHeat < 0)
      {
        return 0;
      }
    }
    return incomingHeat;
  }
}