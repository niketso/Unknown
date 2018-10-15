using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointDetector : MonoBehaviour {

    private MovePlayer pj;
    

    
    private void OnTriggerEnter(Collider other)
    {
        pj = other.GetComponent<MovePlayer>();
        pj.Arrived();
       // Debug.Log(pj.moving);
    }
}
