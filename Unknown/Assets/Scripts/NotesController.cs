using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class NotesController : MonoBehaviour
{
    [SerializeField] private Image noteImage;
    [SerializeField] private GameObject hideNoteButton;



    void Start()
    {
        noteImage.enabled = false;
       hideNoteButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
         GameObject plyr = GameObject.FindGameObjectWithTag("Player") ;
        if (plyr)
        {
            ShowNoteImage();
        }
    }
    
    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        Debug.Log("Text Enabled");
       hideNoteButton.SetActive(true);        
    }

    public void HideNoteImage()
    {
        Debug.Log("HideNoteImage()");
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
      
    }
}