using UnityEngine;

public class CasterUnit : MonoBehaviour
{
  private IPropertyContainer _pc;

  // Start is called before the first frame update
  void Start()
  {
    _pc = GetComponent<SimplePropertyContainer>();
    _pc.AddProperty(new Density());
    var volume = GetComponent<Transform>().localScale.x;
    _pc.AddProperty(new Volume(GetComponent<Transform>(), (int)volume));
    _pc.AddProperty(new Force(GetComponent<Rigidbody>(), 10));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
