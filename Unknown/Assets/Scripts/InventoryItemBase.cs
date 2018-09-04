using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour,IInventoryItem {
    public virtual string Name
    {
        get
        {
            return "_base item_";
        }
    }

    public Sprite _Image;

    public Sprite Image
    {
        get { return _Image; }
    }

    public virtual void OnDrop()
    {
        Debug.Log("OnDrop");
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("ifOnDrop");
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
        Debug.Log("inhabilitadoRed");
    }
    
}
