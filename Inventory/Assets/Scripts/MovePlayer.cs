using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    //private Animator animator;
    private NavMeshAgent agent;
    //public bool isRunning;
    //Camera cam;

    private Vector3 destinationPosition;
    int layerMask;

    void Start()
    {
        //animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        layerMask = LayerMask.GetMask("Destinations", "PickUp");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                agent.destination = hit.point;
            }
        }

        /*if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }

        animator.SetBool("Running", isRunning);*/
    }


}
