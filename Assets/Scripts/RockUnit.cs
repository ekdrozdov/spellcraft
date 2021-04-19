using UnityEngine;

public class RockUnit : MonoBehaviour
{
  private IPropertyContainer _pc;

  // Start is called before the first frame update
  void Start()
  {
    _pc = GetComponent<SimplePropertyContainer>();
    var defVolume = GetComponent<Transform>().localScale.x;
    var volume = new Volume(GetComponent<Transform>(), GetComponent<BoxCollider>(), new IntLimiter(1, 5), (int)defVolume);
    Mass mass = new Mass(_pc.AddProperty(volume), _pc.AddProperty(new Density(new IntLimiter(1, 5))), GetComponent<Rigidbody>());
    _pc.AddProperty(mass);
    _pc.AddProperty(new Force(GetComponent<Rigidbody>()));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
