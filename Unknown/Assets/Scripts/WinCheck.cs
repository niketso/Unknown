using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour {

    private void OnTriggerEnter(Collider collider)
    {
        GameObject plyr = GameObject.FindGameObjectWithTag("Player");
        MovePlayer movePlayer = plyr.GetComponent<MovePlayer>();

        if (collider.tag == "Player" && movePlayer.hasRopa == true)
        {
            WinScene();
        }
       

    }

    public void WinScene()
    {
        SceneManager.LoadScene("WinMenu");
    }
}
