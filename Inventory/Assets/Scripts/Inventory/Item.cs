using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Item
{

    [SerializeField]
    protected ItemDefinition definition;
    [SerializeField]
    protected int amount = 0;

    public virtual string DisplayName
    {
        get
        {
            return this.definition.name;
        }
    }

    public virtual ItemDefinition Definition
    {
        get
        {
            return this.definition;
        }
    }

    public virtual int Amount
    {
        get
        {
            return this.amount;
        }
        set
        {
            this.amount = value;
        }
    }

    public Item(ItemDefinition definition, int amount)
    {
        this.definition = definition;
        this.amount = amount;
    }

}
