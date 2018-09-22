using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    
   [SerializeField] GameObject radio;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }    

    public void DistractZombie()
    {
        agent.destination = radio.transform.position;

        //Destroy(this.gameObject);
    }
}
