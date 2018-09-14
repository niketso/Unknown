using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggingSlot : MonoBehaviour
{

    [SerializeField]
    protected Slot slot;

    [Header("UI References")]
    [SerializeField]
    protected Image image;

    protected Slot cachedSlot;

    public virtual Slot Slot
    {
        get
        {
            return this.slot;
        }
        set
        {
            if (value == null)
            {

                // Cache the slot
                this.cachedSlot = this.slot;
            }
            this.slot = value;
            if (this.slot != null && this.slot.Item != null)
            {
                this.image.color = Color.white;
                Debug.Log(this.slot.Item.Definition);
                this.image.sprite = this.slot.Item.Definition.Icon;
            }
            else
            {

                // Hide the dragging slot when we don't have any slot already dragging or it is dropped
                this.image.color = new Color(0f, 0f, 0f, 0f);
            }
        }
    }

    public virtual Slot CachedSlot
    {
        get
        {
            return this.slot ?? this.cachedSlot;
        }
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (this.slot != null)
        {
            transform.position = eventData.position;
        }
    }

}
