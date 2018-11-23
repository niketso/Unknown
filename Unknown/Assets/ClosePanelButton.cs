using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanelButton : MonoBehaviour {

    GameObject panel;
    GameObject popUpPanel;
    GameObject cube;
    

    private void Awake()
    {
        popUpPanel = GameObject.Find("PopUpBackground");
        cube = GameObject.Find("-");
        Time.timeScale = 0;
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ClosePanel);
        panel = transform.parent.gameObject;
    }

    void ClosePanel()
    {        
        panel.SetActive(false);
        cube.SetActive(false);
        Time.timeScale = 1;
        popUpPanel.SetActive(true);
        
    }
}
