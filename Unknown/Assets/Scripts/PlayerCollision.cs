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

    
    [SerializeField]
    private GameObject goToCorridor;
    [SerializeField]
    private GameObject goToLobby;
    [SerializeField]
    private GameObject escapeHospital;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
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
            cam1.transform.localPosition = new Vector3(13.487f, 30.924f, 9.782f);
            cam1.transform.localRotation = Quaternion.Euler(14.635f, 111f, -0.591f);
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
            goToCorridor.transform.position = new Vector3(goToCorridor.transform.position.x, goToCorridor.transform.position.y - 10, goToCorridor.transform.position.z);
        }

        if (other.tag == "Corridor2")
        {
            cam1.transform.localPosition = new Vector3(13.75034f, 29.46022f, 10.14731f);
            cam1.transform.localRotation = Quaternion.Euler(8.802f, 163.636f, 0f);
        }

        if (other.tag == "Corridor3")
        {
            cam1.transform.localPosition = new Vector3(13.37023f, 30.50673f, -1.573219f);
            cam1.transform.localRotation = Quaternion.Euler(22.037f, 133.212f, 0f);
            //sideRoom.SetActive(true);
        }

        if (other.tag == "SideRoom")
        {
            cam1.transform.localPosition = new Vector3(26.60147f, 30.50752f, -2.183575f);
            cam1.transform.localRotation = Quaternion.Euler(16.71f, -141.944f, 0f);
        }

        if (other.tag == "Room")
        {
            cam1.transform.localPosition = new Vector3(42.81741f, 31.25477f, 9.659981f);
            cam1.transform.localRotation = Quaternion.Euler(19.631f, -126.681f, 0f);
            //corridor.SetActive(false);
            //room.SetActive(true);
            //goToCorridor.SetActive(true);
            goToCorridor.transform.position = new Vector3(goToCorridor.transform.position.x, goToCorridor.transform.position.y + 10, goToCorridor.transform.position.z);
            //goToRoom.transform.position = new Vector3(goToRoom.transform.position.x, goToRoom.transform.position.y - 10, goToRoom.transform.position.z);
            // goToRoom.SetActive(false);
        }

        /*if (other.tag == "FireExt")
        {
            //sound.PlayOneShot(pickUpSound);
        }*/

        if (other.tag == "Lobby")
        {
            cam1.transform.localPosition = new Vector3(40.34329f, 30.14942f, -14.11259f);
            cam1.transform.localRotation = Quaternion.Euler(19.117f, -137.646f, 0f);
            //lobby.SetActive(true);
            //corridor.SetActive(false);
        }

        if (other.tag == "Radio")
        {
            //sound.PlayOneShot(radioSound, 0.5f);
            escapeHospital.SetActive(true);
        }

        if (other.tag == "Batteries")
        {
            other.gameObject.SetActive(false);
            // other.transform.position = new Vector3(other.transform.position.x, goToRoom.transform.position.y - 10, goToRoom.transform.position.z);
        }
    }
}