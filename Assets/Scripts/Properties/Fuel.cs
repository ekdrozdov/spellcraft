using UnityEngine;

[RequireComponent(typeof(Temperature))]
public class Fuel : MonoBehaviour
{
  public float IgnitionTemperature = 200;
  public float ExtinguishTemperature = 100;
  public bool IsBurning = false;
  public float Value = 10;
  public float Limit = 100;
  public float BaseBurningRate = 20;
  public float HeatConvertionPercent = 0.05f;
  private Temperature _temperature;
  private Humidity _humidity;
  public GameObject BurnOutPrefab;

  void Start()
  {
    _temperature = gameObject.GetComponent<Temperature>();
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
    if (Value == 0)
    {
      BurnOut();
      return 0;
    }
    if (IsBurning)
    {
      var fuelLevel = Value;
      Value -= BaseBurningRate;
      Value -= overheat * HeatConvertionPercent;
      Value = System.Math.Max(Value, 0);
      var delta = fuelLevel - Value;
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