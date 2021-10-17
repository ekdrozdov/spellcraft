using UnityEngine;
using static System.Math;

public class Temperature : MonoBehaviour, IScalarProperty
{
  public float SValue = 25;
  public float Conductivity = 1;
  public float Value { get => SValue; set => SValue = value; }
  public string PropertyName => "Temperature";
  private Fuel _burnable;
  private Humidity _humidity;

  void Start()
  {
    _burnable = gameObject.GetComponent<Fuel>();
    _humidity = gameObject.GetComponent<Humidity>();
  }

  public void IncomingExchange(Temperature affecter)
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

  public float GetChange(Temperature donatingTemp)
  {
    var delta = donatingTemp.Value - Value;
    return Sign(delta) * Min(Abs(delta), Min(donatingTemp.Conductivity, Conductivity));
  }
}