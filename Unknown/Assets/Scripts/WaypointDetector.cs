using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointDetector : MonoBehaviour {
       
    public bool inWaypoint = false;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" )
        {                    
            inWaypoint = true;
            Debug.Log("entro");
        }

            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            inWaypoint = false;
            Debug.Log("salio");

        }
    }

}
