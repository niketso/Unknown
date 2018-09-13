using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDragHandler, IDropHandler, IEndDragHandler
{

    #region Fields

    [SerializeField]
    protected int index = 0;
    [SerializeField]
    protected Item item;

    [Header("General References")]

    // A reference to the inventory for general API calls and accessing variables
    [SerializeField]
    protected Inventory inventory;

    [Header("UI References")]
    [SerializeField]
    protected Image image;
    [SerializeField]
    protected Text amountText;
    [SerializeField]
    protected Text nameText;

    #endregion

    #region Properties

    public virtual int Index
    {
        get
        {
            return this.index;
        }
        set
        {
            this.index = value;
        }
    }

    public virtual Item Item
    {
        get
        {
            return this.item;
        }
        set
        {
            this.item = value;
            if (this.item != null)
            {
                if (this.item.Definition == null)
                {
                    this.item = null;
                }
            }
            UpdateUI();
        }
    }

    #endregion

    #region MonoBehaviour Messages

    protected virtual void OnValidate()
    {
        UpdateUI();
    }

    #endregion

    #region Methods

    public virtual void UpdateUI()
    {
        if (this.item == null || this.item.Definition == null)
        {
            this.image.sprite = null;
            this.amountText.text = "0";
            this.nameText.text = "";
        }
        else
        {
            this.image.sprite = this.item.Definition.Icon;
            this.amountText.text = this.item.Amount.ToString();
            this.nameText.text = this.item.DisplayName;
        }
    }

    #endregion

    #region Drag & Drop

    public void OnDrag(PointerEventData eventData)
    {
        if (this.item == null)
        {
            return;
        }

        // Hide the slot
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0f);
        this.inventory.DraggingSlot.Slot = this;
        this.inventory.DraggingSlot.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        // Show the slot
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 1f);
        this.inventory.DraggingSlot.Slot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (this.inventory.DraggingSlot.Slot == this || this.inventory.DraggingSlot.Slot == null)
        {
            return;
        }
        else
        {

            // Combine the items
            Slot slot = this.inventory.DraggingSlot.Slot;
            Item newItem = this.inventory.DraggingSlot.Slot.Item;
            for (int i = 0; i < newItem.Definition.Recipes.Count; i++)
            {
                Recipe recipe = newItem.Definition.Recipes[i];
                if (recipe.combinee == this.item.Definition)
                {
                    slot.RemoveItem();
                    RemoveItem();
                    this.inventory.AddNewItem(new Item(recipe.result, 1));
                }
            }

            // Actually move the slot (Swap the slots)
            //this.inventory.MoveTo(this.inventory.DraggingSlot.Slot, this);
            //this.inventory.DraggingSlot.Slot = null;
        }
    }

    public bool CanRemoveItem()
    {
        return this.item.Amount > 0;
    }

    public void RemoveItem()
    {
        if (this.item != null)
        {
            if (this.item.Amount > 0)
            {

                // Decrease the amount of item by 1
                this.item.Amount--;
                UpdateUI();
            }
            if (this.item.Amount <= 0)
            {

                // Remove the item when we don't have any amount of it
                this.Item = null;
            }
        }
    }

    #endregion

}
