using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    [SerializeField]
    private Camera cam1;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private MovePlayer func;
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject tapa;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject corridor;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private AudioClip keySound;
    [SerializeField]
    private AudioClip doorSound;
    [SerializeField]
    private AudioClip hurtSound;
    
    private Transform camPos2;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            sound.PlayOneShot(hurtSound);
            func.TakeDamage();
            //SceneManager.LoadScene("GameOver");
        }

    }
    private void OnTriggerEnter(Collider other)
    {        
        func.SetOrigin(other.transform);
        
        if (other.tag == "Container" && func.GetKey())
        {
            Destroy(tapa);
        }

        if(other.tag == "Key")
        {
            func.PickKey();
            Destroy(key);
            sound.PlayOneShot(keySound);
        }

        if(other.tag == "Door" && func.GetKey())
        {
            Destroy(door);
            sound.PlayOneShot(doorSound);
            corridor.SetActive(true);
        }

        if(other.tag == "Corridor")
        {
            cam1.transform.localPosition = new Vector3(13.487f, 30.924f, 9.782f);
            cam1.transform.localRotation = Quaternion.Euler(14.635f, 130.187f, -0.591f);
        }
    }
}
