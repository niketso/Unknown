using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    
    [SerializeField] GameObject radio;
    [SerializeField] GameObject extinguisher;
    [SerializeField] GameObject obs;
    

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }    

    public void DistractZombie()
    {
        agent.destination = radio.transform.position;
        

        
    }

    public void hitZombie()
    {
        //agent.destination = obs.transform.position;
        //Destroy(this.gameObject);
        Object.Destroy(this);
       // DestroyImmediate(this.gameObject,true);
    }
}
