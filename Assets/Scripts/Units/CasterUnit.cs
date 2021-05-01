using UnityEngine;

public class CasterUnit : MonoBehaviour
{
  private IPropertyContainer _pc;

  // Start is called before the first frame update
  void Start()
  {
    _pc = GetComponent<SimplePropertyContainer>();
    _pc.AddProperty(new Density(new IntLimiter(1, 5)));
    var volume = GetComponent<Transform>().localScale.x;
    _pc.AddProperty(new Volume(GetComponent<Transform>(), GetComponent<BoxCollider>(), new IntLimiter(1, 5), (int)volume));
    _pc.AddProperty(new Force(GetComponent<Rigidbody>(), GetComponent<Transform>(), 5));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
