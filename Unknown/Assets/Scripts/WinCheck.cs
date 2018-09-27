using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour {

    private void OnTriggerEnter(Collider collider)
    {
        GameObject plyr = GameObject.FindGameObjectWithTag("Player");
        

        if (collider.tag == "Player")
        {
            WinScene();
        }      

    }

    public void WinScene()
    {
        SceneManager.LoadScene("WinMenu");
    }
}
