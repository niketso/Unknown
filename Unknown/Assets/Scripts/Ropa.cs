using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ropa : MonoBehaviour {

    
    [SerializeField] Material mat;
    [SerializeField] GameObject consumable;

    private void OnTriggerEnter(Collider other)
    {
        GameObject plyr = GameObject.FindGameObjectWithTag("Player");
        if (plyr)
        {
            MeshRenderer plyrMesh = plyr.GetComponent<MeshRenderer>();
            plyrMesh.material = mat; 
        }

        Destroy(consumable);
    }

    
}
