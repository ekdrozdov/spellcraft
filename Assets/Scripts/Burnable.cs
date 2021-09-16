using UnityEngine;

public class Burnable : MonoBehaviour
{
  public int IgnitionTemperature = 200;
  public bool IsBurning = false;
  public int Fuel = 100;
  public int BurningRate = 20;
  private TemperatureV2 _temperature;
  public GameObject BurnOutPrefab;

  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
  }

  void Update()
  {

  }

  public int Consume(int incomingHeat)
  {
    if (_temperature.Value >= IgnitionTemperature)
    {
      IsBurning = true;
    }
    if (Fuel <= 0)
    {
      Transform lastTransform = this.transform;
      GameObject.Destroy(this.gameObject);
      Instantiate(BurnOutPrefab, lastTransform.position, lastTransform.rotation);
      return 0;
    }
    if (IsBurning)
    {
      Fuel -= BurningRate;
      if (incomingHeat < 0)
      {
        return 0;
      }
    }
    return incomingHeat;
  }
}