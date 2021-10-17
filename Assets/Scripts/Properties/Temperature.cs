using UnityEngine;
using static System.Math;

public class Temperature : MonoBehaviour, IScalarProperty
{
  public float Value = 25;
  public float Conductivity = 1;
  public float Property { get => Value; set => Value = value; }
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
    Property += delta;
  }

  public float GetChange(Temperature donatingTemp)
  {
    var delta = donatingTemp.Property - Property;
    return Sign(delta) * Min(Abs(delta), Min(donatingTemp.Conductivity, Conductivity));
  }
}