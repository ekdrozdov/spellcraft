using UnityEngine;

public class RockUnit : MonoBehaviour
{
  private IPropertyContainer _pc;

  // Start is called before the first frame update
  void Start()
  {
    _pc = GetComponent<SimplePropertyContainer>();
    var defVolume = GetComponent<Transform>().localScale.x;
    var volume = new Volume(GetComponent<Transform>(), (int)defVolume);
    Mass mass = new Mass(_pc.AddProperty(volume), _pc.AddProperty(new Density()), GetComponent<Rigidbody>());
    _pc.AddProperty(mass);
    _pc.AddProperty(new Force(GetComponent<Rigidbody>()));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
