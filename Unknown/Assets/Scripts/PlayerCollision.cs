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
    private GameObject gotoLobby;
    [SerializeField]
    private GameObject lobby;
    [SerializeField]
    private GameObject escapeHospital;
    [SerializeField]
    private GameObject bed;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private AudioClip pickUpSound;
    [SerializeField]
    private AudioClip doorSound;
    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip radioSound;




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
            sound.PlayOneShot(pickUpSound);
        }

        if(other.tag == "Door" && func.GetKey())
        {
            Destroy(door);
            sound.PlayOneShot(doorSound);
            corridor.SetActive(true);
            gotoLobby.SetActive(true);
        }

        if(other.tag == "Corridor")
        {
            cam1.transform.localPosition = new Vector3(13.487f, 30.924f, 9.782f);
            cam1.transform.localRotation = Quaternion.Euler(14.635f, 130.187f, -0.591f);
            bed.SetActive(false);
        }

        if(other.tag == "FireExt")
        {
            sound.PlayOneShot(pickUpSound);
        }

        if(other.tag == "Lobby")
        {
            cam1.transform.localPosition = new Vector3(42.5119f, 31.492f, -14.42264f);
            cam1.transform.localRotation = Quaternion.Euler(19.116f, -135.103f, 0f);
            lobby.SetActive(true);
            corridor.SetActive(false);
        }

        if(other.tag == "Radio")
        {
            sound.PlayOneShot(radioSound);
            escapeHospital.SetActive(true);
        }
    }
}