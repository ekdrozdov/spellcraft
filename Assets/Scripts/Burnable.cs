using UnityEngine;

public class Burnable : MonoBehaviour
{
  public int IgnitionTemperature = 200;
  public bool isBurning = false;
  public int Fuel = 100;
  public int BurningRate = 20;
  private TemperatureV2 _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
  }

  void Update()
  {

  }

  public void Burn()
  {
    if (_temperature.Value >= IgnitionTemperature)
    {
      isBurning = true;
    }
    if (Fuel <= 0)
    {
      // Destroy.
    }
    if (isBurning)
    {
      Fuel -= BurningRate;
    }
  }
}