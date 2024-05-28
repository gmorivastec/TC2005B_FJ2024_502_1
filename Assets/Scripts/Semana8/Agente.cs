using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Agente : MonoBehaviour
{

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento por click
        if(Input.GetMouseButtonDown(0))
        {
            // fabricar rayito
            Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);

            // utilizamos un out parameter
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters#out-parameter-modifier
            RaycastHit hit;

            // ver si pegó 
            if(Physics.Raycast(rayito, out hit))
            {
                print("PEGÓ!");
                _agent.destination = hit.point;
            }
        }
    }
}
