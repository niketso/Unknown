using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour {

    public Inventory inventory;
    private CharacterController cc;
    private NavMeshAgent agent;
    int layermask;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //cc = GetComponent<CharacterController>();       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {

            Debug.Log("onTriggerEnter");
            IInventoryItem item = other.GetComponent<IInventoryItem>();

            if (item != null)
            {
                Debug.Log("IFdelOntriggerE");
                inventory.AddItem(item);
            }
        }
    }

    /*private void OnItemHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }*/
}

