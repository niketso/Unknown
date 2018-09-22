using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //func.TakeDamage();
            SceneManager.LoadScene("GameOver");
        }

    }
    private void OnTriggerEnter(Collider other)
    {        
        func.SetOrigin(other.transform);
        
        if (func.GetKey())
        {
            //Destroy(tapa);
        }
    }
    

}
