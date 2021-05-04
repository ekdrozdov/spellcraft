using UnityEngine;

public class TreeUnit : MonoBehaviour
{
  private IPropertyContainer _pc;
  public GameObject LogPrefab;
  private Durability _durability;

  // Start is called before the first frame update
  void Start()
  {
    _pc = GetComponent<SimplePropertyContainer>();
    var defVolume = GetComponent<Transform>().localScale.x;
    var volume = new Volume(GetComponent<Transform>(), GetComponent<BoxCollider>(), new IntLimiter(1, 5), (int)defVolume);
    Mass mass = new Mass(_pc.AddProperty(volume), _pc.AddProperty(new Density(new IntLimiter(1, 5))), GetComponent<Rigidbody>());
    _pc.AddProperty(mass);
    var force = new Force(GetComponent<Rigidbody>(), GetComponent<Transform>());
    _pc.AddProperty(force);
    _durability = new Durability(7, force, this.gameObject, GetComponent<Transform>(), GetComponent<Rigidbody>());
    _pc.AddProperty(_durability);
    _pc.AddProperty(new Temperature(new IntLimiter(0, 200), GetComponent<Transform>()));
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter(Collision collision)
  {
    _durability.Update((int)collision.impulse.magnitude);
  }

  public void Break(Vector3 thrust)
  {
    Transform t = this.transform;
    GameObject.Destroy(this.gameObject);
    var log = Instantiate(LogPrefab, t.position, t.rotation);
    // TODO: inherit props, e.g. Volume
    // log.GetComponent<Volume>().Update((int)t.localScale.x - 1);
    log.GetComponent<Rigidbody>().AddForce(thrust / 2, ForceMode.Impulse);
  }
}
