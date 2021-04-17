using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CasterUnit : MonoBehaviour
{
    private IPropertyContainer _pc;

    // Start is called before the first frame update
    void Start()
    {
        _pc = GetComponent<SimplePropertyContainer>();
        _pc.AddProperty(new Density());
        _pc.AddProperty(new Volume());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
