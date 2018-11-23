using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanelButton : MonoBehaviour {

    GameObject panel;

    private void Awake()
    {
        Time.timeScale = 0;
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ClosePanel);
        panel = transform.parent.gameObject;
    }

    void ClosePanel()
    {        
        panel.SetActive(false);
        Time.timeScale = 1;        
    }
}
