using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ReplayButton : MonoBehaviour
{

    private void Awake()
    {
        var btn2 = GetComponent<Button>();
        btn2.onClick.AddListener(Replay);
    }

    public void Replay()
    {
        SceneManager.LoadScene("HospitalPrototipo");
    }

}