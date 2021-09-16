using UnityEngine;
using static System.Math;

public class TemperatureV2 : MonoBehaviour
{
  public float Value = 25;
  public float Conductivity = 1;

  private Burnable _burnable;
  private Humidity _humidity;

  void Start()
  {
    _burnable = gameObject.GetComponent<Burnable>();
    _humidity = gameObject.GetComponent<Humidity>();

  }

  void Update()
  { }

  public void IncomingExchange(TemperatureV2 affecter)
  {
    var delta = GetChange(affecter);
    if (_humidity != null)
    {
      delta = _humidity.Consume(delta);
    }
    if (_burnable != null)
    {
      delta = _burnable.Consume(delta);
    }
    Value += delta;
  }

  public float GetChange(TemperatureV2 donatingTemp)
  {
    var delta = donatingTemp.Value - Value;
    return Sign(delta) * Min(Abs(delta), Min(donatingTemp.Conductivity, Conductivity));
  }
}