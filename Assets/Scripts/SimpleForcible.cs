using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleForcible : MonoBehaviour, Forcible
{
    private Rigidbody _body;

    public void ApplyForce(Vector3 direction)
    {
        _body.AddForce(direction, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
