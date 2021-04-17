using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RockUnit : MonoBehaviour
{
    private IPropertyContainer _pc;

    // Start is called before the first frame update
    void Start()
    {
        _pc = GetComponent<SimplePropertyContainer>();
        Volume volume = new Volume();
        Mass mass = new Mass(_pc.AddProperty(volume), _pc.AddProperty(new Density()), GetComponent<Rigidbody>());
        _pc.AddProperty(mass);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
