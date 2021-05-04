using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogUnit : MonoBehaviour
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
    var force = new Force(GetComponent<Rigidbody>(), GetComponent<Transform>());
    _pc.AddProperty(force);
    _pc.AddProperty(new Temperature(new IntLimiter(0, 200), GetComponent<Transform>()));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
