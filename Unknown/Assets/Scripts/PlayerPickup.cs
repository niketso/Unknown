using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{

    [SerializeField]
    protected Inventory inventory;

    public virtual Inventory Inventory
    {
        get
        {
            return this.inventory;
        }
    }

}
