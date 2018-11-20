using System;
using UnityEngine;

public class DoorBehaviour : BasePuzzleBehaviour
{
    public string puzzleSolverPrefabName;
    //protected override void CheckInventory()
    //{
    //    if (InventoryContainsItem(puzzleSolverPrefabName))
    //    {
    //        //open the door
    //        //this.gameObject.transform=
    //        //gameObject.SetActive(false);
    //    }
    //}
    public bool isUnlocked = false;


    [SerializeField]
    private AudioSource sound;

    [SerializeField]
    private AudioClip doorSound;
    private bool playerIsAtTheDoor = false;
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject)//to figure out
        //{
        //    isUnlocked = true;
        //    UseItem(puzzleSolverPrefabName);
        //}
        if (other.tag == "Player")
        {
            playerIsAtTheDoor = true;
            if (isUnlocked)
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        gameObject.SetActive(false);
        sound.PlayOneShot(doorSound);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsAtTheDoor = false;
        }

    }
    protected override void OnDropInternal(GameObject slot)
    {
        if (slot.name == puzzleSolverPrefabName)
        {
            Unlock();
        }
    }

    internal void Unlock()
    {
        isUnlocked = true;
        UseItem(puzzleSolverPrefabName);
        if (playerIsAtTheDoor)
            OpenDoor();
    }
}
