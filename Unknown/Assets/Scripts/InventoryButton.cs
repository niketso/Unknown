using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    public GameObject inventory;

    Vector3 inventoryOriginalPos;
    Vector3 buttonOriginalPos;
    Vector3 inventoryHidePos;
    Vector3 buttonHidePos;

    private bool hidden = true;

    private void Awake()
    {
        var btn = GetComponent<Button>();
        //btn.onClick.AddListener(EventManager_InventoryMoved);
        btn.onClick.AddListener(MoveInventory);

        inventoryOriginalPos = inventory.transform.position;
        buttonOriginalPos = this.transform.position;

        inventoryHidePos = inventoryOriginalPos + new Vector3(230, 0, 0);
        buttonHidePos = buttonOriginalPos + new Vector3(230, 0, 0);

    }
   
    private void Update()
    {
        if (hidden)
        {
            this.transform.position = buttonHidePos;
            inventory.transform.position = inventoryHidePos;
        }
        else
        {
            this.transform.position = buttonOriginalPos;
            inventory.transform.position = inventoryOriginalPos;
        }
    }    

    private void MoveInventory()
    {
        Debug.Log("------MOVE------");
        if (hidden)
            hidden = false;
        else
            hidden = true;
    }
}
