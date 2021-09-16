using UnityEngine;

public class TemperatureFieldV3 : MonoBehaviour
{
  private TemperatureV2 _temperature;

  // Start is called before the first frame update
  void Start()
  {
    _temperature = gameObject.GetComponent<TemperatureV2>();
    InvokeRepeating("UpdateObjectTemperatures", 1.0f, 1.0f);
  }

  // Update is called once per frame
  void Update()
  {

  }

  void UpdateObjectTemperatures()
  {
    TemperatureV2[] temperatures = Object.FindObjectsOfType<TemperatureV2>();
    foreach (var temperature in temperatures)
    {
      if (temperature != _temperature)
      {
        // Environment temperature impact.
        var residentTemprature = temperature.GetComponent<TemperatureV2>();
        residentTemprature.IncomingExchange(_temperature);

        // Impact overlapping burnables temperature.
        var burnable = residentTemprature.GetComponent<Burnable>();
        if (burnable != null && burnable.IsBurning)
        {
          Collider[] hitColliders = Physics.OverlapSphere(residentTemprature.transform.position, 3.0f);
          foreach (var hitCollider in hitColliders)
          {
            var affectedTemperature = hitCollider.GetComponent<TemperatureV2>();
            if (affectedTemperature != null && affectedTemperature.Value < residentTemprature.Value)
            {
              affectedTemperature.IncomingExchange(residentTemprature);
            }
          }
        }
      }
    }
  }
}
