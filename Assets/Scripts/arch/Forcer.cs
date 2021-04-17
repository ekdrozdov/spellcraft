using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    Rigidbody r;
    public Vector3 thrust = new Vector3(2, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            r.AddForce(thrust, ForceMode.Impulse);
        }
    }
}
