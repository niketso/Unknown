using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public GameObject player;
    public MovePlayer func;


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            func.TakeDamage();   
        }

    }
    private void OnTriggerEnter(Collider other)
    {        
            Debug.Log("casd");
            func.SetOrigin(other.transform);
    }
    

}
