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
    private AudioSource sound;
    [SerializeField]
    private AudioClip pickUpSound;
    [SerializeField]
    private AudioClip doorSound;
    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip radioSound;


    [SerializeField]
    private GameObject corridor;
    [SerializeField]
    private GameObject goToCorridor;    
    [SerializeField]
    private GameObject lobby;
    [SerializeField]
    private GameObject goToLobby;
    [SerializeField]
    private GameObject escapeHospital;
    [SerializeField]
    private GameObject room;
    [SerializeField]
    private GameObject goToRoom;
    


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            sound.PlayOneShot(hurtSound);
            func.TakeDamage();
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

        if(other.tag == "Door" && func.GetKey()) //cambiar y poner llave como item para arrastrar a la puerta, crear script de puertas
        {
            //Destroy(door);
            door.transform.position = new Vector3(0, -10, 0);
            sound.PlayOneShot(doorSound);
            goToCorridor.SetActive(true);
            goToLobby.SetActive(true);
        }

        if(other.tag == "Corridor")
        {
            cam1.transform.localPosition = new Vector3(13.487f, 30.924f, 9.782f);
            cam1.transform.localRotation = Quaternion.Euler(14.635f, 130.187f, -0.591f);
            corridor.SetActive(true);
            room.SetActive(false);
           
            //goToCorridor.SetActive(false);
            if (goToRoom.active == true)
            {
                goToRoom.transform.position = new Vector3(goToRoom.transform.position.x, goToRoom.transform.position.y + 10, goToRoom.transform.position.z);
            }
            else
            {
                goToRoom.SetActive(true);
            }
            
            goToCorridor.transform.position = new Vector3(goToCorridor.transform.position.x, goToCorridor.transform.position.y - 10, goToCorridor.transform.position.z);
        }

        if (other.tag == "Room")
        {
            cam1.transform.localPosition = new Vector3(42.81741f, 31.25477f, 9.659981f);
            cam1.transform.localRotation = Quaternion.Euler(19.631f, -126.681f, 0f);
            corridor.SetActive(false);
            room.SetActive(true);
            //goToCorridor.SetActive(true);
            goToCorridor.transform.position = new Vector3(goToCorridor.transform.position.x, goToCorridor.transform.position.y + 10, goToCorridor.transform.position.z);
            goToRoom.transform.position = new Vector3(goToRoom.transform.position.x, goToRoom.transform.position.y - 10, goToRoom.transform.position.z);
           // goToRoom.SetActive(false);
        }

        if (other.tag == "FireExt")
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
            sound.PlayOneShot(radioSound, 0.5f);
            escapeHospital.SetActive(true);
        }
    }
}