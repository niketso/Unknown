using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour, IInventoryItem {

	public string Name
    {
        get
        {
            return "Red Cube";
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
        Debug.Log("inhabilitado");
    }
}
