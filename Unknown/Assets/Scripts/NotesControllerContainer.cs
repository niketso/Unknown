using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class NotesControllerContainer : MonoBehaviour
{
    [SerializeField] private Image noteImage;
    [SerializeField] private Image noteImageClosed;
    [SerializeField] private GameObject hideNoteButton;
    [SerializeField] private GameObject hideNoteButtonClosed;
    public MovePlayer player;
    [SerializeField]
    private GameObject tapa;

    void Start()
    {
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
        noteImageClosed.enabled = false;
        hideNoteButtonClosed.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject plyr = GameObject.FindGameObjectWithTag("Player");
        if (plyr)
        {
            if (!player.GetKey())
                ShowNoteImageClosed();
            else if (player.GetKey())
            {
                Destroy(tapa);
                ShowNoteImage();
            }
        }
    }
    
    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        Debug.Log("Text Enabled");
        hideNoteButton.SetActive(true);        
    }
    public void ShowNoteImageClosed()
    {
        noteImageClosed.enabled = true;
        Debug.Log("Text Enabled");
        hideNoteButtonClosed.SetActive(true);
    }

    public void HideNoteImage()
    {
        Debug.Log("HideNoteImage()");
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);      
    }
    public void HideNoteImageClosed()
    {
        Debug.Log("HideNoteImageClosed()");
        noteImageClosed.enabled = false;
        hideNoteButtonClosed.SetActive(false);
    }

}