using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : MonoBehaviour, IInventoryItem
{

    public string Name
    {
        get
        {
            return "Blue Cube";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        //falta que pasa cuando se agarra
        gameObject.SetActive(false);
        Debug.Log("inhabilitadoBlue");
    }
}