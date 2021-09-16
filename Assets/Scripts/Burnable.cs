using UnityEngine;

public class Burnable : MonoBehaviour
{
  public float IgnitionTemperature = 200;
  public bool IsBurning = false;
  public float Fuel = 100;
  public float BurningRate = 20;
  private TemperatureV2 _temperature;
  public GameObject BurnOutPrefab;

  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
  }

  void Update()
  {

  }

  public float Consume(float incomingHeat)
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