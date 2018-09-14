using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    protected DraggingSlot draggingSlot;

    [SerializeField]
    protected List<Slot> slots = new List<Slot>();
    [SerializeField]
    protected ItemDefinition apple;
    [SerializeField]
    protected ItemDefinition tomato;
    [SerializeField]
    protected ItemDefinition potato;

    public virtual DraggingSlot DraggingSlot
    {
        get
        {
            return this.draggingSlot;
        }
        set
        {
            this.draggingSlot = value;
        }
    }

    protected virtual void Awake()
    {
        AddNewItem(new Item(this.apple, 5));
        AddNewItem(new Item(this.tomato, 5));
        AddNewItem(new Item(this.potato, 5));
    }

    protected virtual void OnValidate()
    {
        this.slots.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Slot slot = child.GetComponent<Slot>();
            slot.Index = i;
            this.slots.Add(slot);
        }
    }

    /// <summary>
    /// Move slots from an index to another.
    /// </summary>
    /// <param name="oldIndex"></param>
    /// <param name="newIndex"></param>
    public virtual void MoveToByIndex(int oldIndex, int newIndex)
    {
        MoveTo(this.slots[oldIndex], this.slots[newIndex]);
    }

    /// <summary>
    /// Move slots from an index to another.
    /// </summary>
    /// <param name="oldSlot"></param>
    /// <param name="newSlot"></param>
    public virtual void MoveTo(Slot oldSlot, Slot newSlot)
    {

        // Update slots item
        Item item = oldSlot.Item;
        oldSlot.Item = newSlot.Item;
        newSlot.Item = item;
    }

    /// <summary>
    /// Adds new item to the first empty slot.
    /// </summary>
    /// <param name="item"></param>
    public virtual void AddNewItem(Item item)
    {
        Slot resultSlot = GetSlotOfStack(item.Definition);
        if (resultSlot == null)
        {
            resultSlot = GetEmptySlot();
        }
        if (resultSlot != null)
        {
            if (resultSlot.Item != null && resultSlot.Item.Definition == item.Definition)
            {
                resultSlot.Item.Amount += item.Amount;
                resultSlot.UpdateUI();
            }
            else
            {
                resultSlot.Item = item;
            }
        }
    }

    /// <summary>
    /// Retrieves the first empty slot.
    /// </summary>
    /// <returns></returns>
    public virtual Slot GetEmptySlot()
    {
        Slot slot = null;
        for (int i = 0; i < this.slots.Count; i++)
        {

            // Check whether the slot is empty, then break the loop and return the slot
            if (this.slots[i].Item == null)
            {
                slot = this.slots[i];
                break;
            }
        }
        return slot;
    }

    public virtual Slot GetSlotOfStack(ItemDefinition definition)
    {
        Slot slot = null;
        for (int i = 0; i < this.slots.Count; i++)
        {
            if (this.slots[i].Item != null && this.slots[i].Item.Definition == definition)
            {
                slot = this.slots[i];
                break;
            }
        }
        return slot;
    }

}
