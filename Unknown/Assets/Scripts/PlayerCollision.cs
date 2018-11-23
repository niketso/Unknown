using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]
    private Camera cam1;
    [SerializeField]
    private GameObject player;
   
    private MovePlayer func;
    [SerializeField]
    private GameObject tapa;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip radioSound;

    private GameObject arrow1;


    //[SerializeField]
    //private GameObject goToCorridor;
    //[SerializeField]
    //private GameObject goToLobby;
    //[SerializeField]
    //private GameObject escapeHospital;

    private void Awake()
    {
        arrow1 = GameObject.Find("Go back to corner");
    }

    private void Update()
    {
        //if(arrow1)
        //Debug.Log("ARROW" + arrow1.name);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy"|| collisionInfo.collider.tag == "Fire")
        {
            sound.PlayOneShot(hurtSound);
            func.TakeDamage();
        }
    }
    private void OnEnable()
    {
        func = gameObject.GetComponent<MovePlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        func.SetOrigin(other.transform);

        //if (other.tag == "Container" && func.GetKey())
        //{
        //    Destroy(tapa);
        //}

        /*if (other.tag == "Key")
        {
            //func.PickKey();
            //other.gameObject.SetActive(false);
            //other.transform.position = new Vector3(other.transform.position.x, goToRoom.transform.position.y - 10, goToRoom.transform.position.z);
            //Destroy(key);
        }*/

        //if(other.tag == "Door" && func.GetKey()) //cambiar y poner llave como item para arrastrar a la puerta, crear script de puertas
        //{
        //    //Destroy(door);
        //    //door.transform.position = new Vector3(0, -10, 0);
        //    //sound.PlayOneShot(doorSound);//moved to doorbehaviour
        //    //goToCorridor.SetActive(true);
        //    //goToLobby.SetActive(true);
        //}

        if (other.tag == "Corridor")
        {
            cam1.transform.localPosition = new Vector3(13.40071f, 30.40394f, 9.793617f);
            cam1.transform.localRotation = Quaternion.Euler(20.494f, 134.969f, 0f);
            arrow1.SetActive(false);
            //corridor.SetActive(true);
            //room.SetActive(false);

            //goToCorridor.SetActive(false);
            //if (goToRoom.activeSelf == true)
            //{
            //    goToRoom.transform.position = new Vector3(goToRoom.transform.position.x, goToRoom.transform.position.y + 10, goToRoom.transform.position.z);
            //}
            //else
            //{
            //    goToRoom.SetActive(true);
            //}
            //other.gameObject.SetActive(false);
            //goToCorridor.transform.position = new Vector3(goToCorridor.transform.position.x, goToCorridor.transform.position.y - 10, goToCorridor.transform.position.z);
        }

        if (other.tag == "Corridor2")
        {
            cam1.transform.localPosition = new Vector3(13.40071f, 30.40394f, 9.793617f);
            cam1.transform.localRotation = Quaternion.Euler(20.494f, 134.969f, 0f);
            arrow1.SetActive(false);
        }

        if (other.tag == "WaitingRoom")
        {
            cam1.transform.localPosition = new Vector3(42.71601f, 30.13642f, -25.16028f);
            cam1.transform.localRotation = Quaternion.Euler(14.994f, -56.342f, 0f);
            arrow1.SetActive(false);
        }

        if (other.tag == "Corridor3")
        {
            cam1.transform.localPosition = new Vector3(13.37023f, 30.50673f, -1.573219f);
            cam1.transform.localRotation = Quaternion.Euler(22.037f, 133.212f, 0f);
            arrow1.SetActive(true);
            //sideRoom.SetActive(true);
        } 

        if (other.tag == "SideRoom")
        {
            cam1.transform.localPosition = new Vector3(26.60147f, 30.50752f, -2.183575f);
            cam1.transform.localRotation = Quaternion.Euler(16.71f, -141.944f, 0f);
            arrow1.SetActive(false);
        }

        if (other.tag == "Room")
        {
            cam1.transform.localPosition = new Vector3(38.45164f, 30.21566f, 9.782761f);
            cam1.transform.localRotation = Quaternion.Euler(20.322f, -130.665f, 0f);
            arrow1.SetActive(false);
            //corridor.SetActive(false);
            //room.SetActive(true);
            //goToCorridor.SetActive(true);
            //goToCorridor.transform.position = new Vector3(goToCorridor.transform.position.x, goToCorridor.transform.position.y + 10, goToCorridor.transform.position.z);
            //goToRoom.transform.position = new Vector3(goToRoom.transform.position.x, goToRoom.transform.position.y - 10, goToRoom.transform.position.z);
            // goToRoom.SetActive(false);
        }

        /*if (other.tag == "FireExt")
        {
            //sound.PlayOneShot(pickUpSound);
        }*/

        if (other.tag == "Lobby")
        {
            cam1.transform.localPosition = new Vector3(40.433f, 30.139f, -14.233f);
            cam1.transform.localRotation = Quaternion.Euler(18.701f, -125.226f, 0f);
            arrow1.SetActive(false);
            //lobby.SetActive(true);
            //corridor.SetActive(false);
        }

        if (other.tag == "Corner")
        {
            cam1.transform.localPosition = new Vector3(25.593f, 31.42826f, -14.249f);
            cam1.transform.localRotation = Quaternion.Euler(25.99f, -115.577f, 0f);
            //arrow1.SetActive(false);
            //lobby.SetActive(true);
            //corridor.SetActive(false);
        }

        if (other.tag == "Radio")
        {
            sound.PlayOneShot(radioSound, 0.5f);
            //escapeHospital.SetActive(true);
        }

        if (other.tag == "Batteries")
        {
            other.gameObject.SetActive(false);
            // other.transform.position = new Vector3(other.transform.position.x, goToRoom.transform.position.y - 10, goToRoom.transform.position.z);
        }
    }
}