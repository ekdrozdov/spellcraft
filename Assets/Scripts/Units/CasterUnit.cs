using UnityEngine;

public class CasterUnit : MonoBehaviour
{
  private IPropertyContainer _pc;

  // Start is called before the first frame update
  void Start()
  {
    _pc = GetComponent<SimplePropertyContainer>();
    _pc.AddProperty(new DensityPower(new IntLimiter(1, 5)));
    var volume = GetComponent<Transform>().localScale.x;
    _pc.AddProperty(new VolumePower(new IntLimiter(1, 5)));
    _pc.AddProperty(new ForcePower(new IntLimiter(0, 10), 5));
    _pc.AddProperty(new HealthPower(new IntLimiter(0, 8)));
    _pc.AddProperty(new TemperaturePower(new IntLimiter(0, 10)));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
