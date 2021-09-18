using UnityEngine;

[RequireComponent(typeof(Temperature))]
public class TemperatureField : MonoBehaviour
{
  private Temperature _temperature;

  void Start()
  {
    _temperature = gameObject.GetComponent<Temperature>();
    InvokeRepeating("Interaction", 1.0f, 1.0f);
  }

  void Update()
  {

  }

  void Interaction()
  {
    Temperature[] temperatures = Object.FindObjectsOfType<Temperature>();
    foreach (var temperature in temperatures)
    {
      if (temperature != _temperature)
      {
        // Environment temperature impact.
        var residentTemprature = temperature.GetComponent<Temperature>();
        residentTemprature.IncomingExchange(_temperature);

        // Impact overlapping burnables temperature.
        var burnable = residentTemprature.GetComponent<Fuel>();
        if (burnable != null && burnable.IsBurning)
        {
          Collider[] hitColliders = Physics.OverlapSphere(residentTemprature.transform.position, 3.0f);
          foreach (var hitCollider in hitColliders)
          {
            var affectedTemperature = hitCollider.GetComponent<Temperature>();
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
