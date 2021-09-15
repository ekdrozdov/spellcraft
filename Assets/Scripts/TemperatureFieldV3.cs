using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class TemperatureFieldV3 : MonoBehaviour
{
  public int InitTemperature = 25;
  public int Conductivity = 5;

  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("UpdateObjectTemperatures", 1.0f, 1.0f);
  }

  // Update is called once per frame
  void Update()
  {

  }

  void UpdateObjectTemperatures()
  {
    var environmentTemperature = new TemperatureV2();
    environmentTemperature.Value = InitTemperature;
    environmentTemperature.Conductivity = Conductivity;

    Burnable[] burnables = Object.FindObjectsOfType<Burnable>();
    foreach (var burnable in burnables)
    {
      burnable.Burn();

      // Environment temperature impact.
      var residentTemprature = burnable.GetComponent<TemperatureV2>();
      var change = getChange(environmentTemperature, residentTemprature);
      residentTemprature.Value += change;

      // Impact overlapping burnables temperature.
      Collider[] hitColliders = Physics.OverlapSphere(burnable.transform.position, 3.0f);
      foreach (var hitCollider in hitColliders)
      {
        var affectedTemperature = hitCollider.GetComponent<TemperatureV2>();
        if (affectedTemperature != null && affectedTemperature != residentTemprature)
        {
          affectedTemperature.Value += getChange(residentTemprature, affectedTemperature);
        }
      }
    }
  }

  private int getChange(TemperatureV2 donatingTemp, TemperatureV2 affectedTemp)
  {
    var delta = donatingTemp.Value - affectedTemp.Value;
    return Sign(delta) * Min(Abs(delta), Min(donatingTemp.Conductivity, affectedTemp.Conductivity));
  }
}
