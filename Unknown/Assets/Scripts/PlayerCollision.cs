using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {


    [SerializeField]
    private GameObject player;
    [SerializeField]
    private MovePlayer func;
    [SerializeField]
    private GameObject tapa;


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            func.TakeDamage();   
        }

    }
    private void OnTriggerEnter(Collider other)
    {        
        func.SetOrigin(other.transform);
        
        if (func.GetKey())
        {
            Destroy(tapa);
        }
    }
    

}
