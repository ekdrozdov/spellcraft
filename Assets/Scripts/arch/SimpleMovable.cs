using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovable : MonoBehaviour, Movable
{
    NavMeshAgent agent;

    public void MoveTo(Vector3 destination)
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.destination = destination;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}
