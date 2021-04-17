using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
  public Vector3 Thrust = new Vector3(5, 0, 0);
  public Forcible Target;

  // Start is called before the first frame update
  void Start()
  {
    Target = GameObject.Find("MyRock").GetComponent<SimpleForcible>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      Target.ApplyForce(Thrust);
    }
  }
}
