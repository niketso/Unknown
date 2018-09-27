using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{

    [SerializeField]
    protected Inventory inventory;

    public void OnDrop(PointerEventData eventData)
    {
        if (this.inventory.DraggingSlot.Slot == null)
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Terrain") && this.inventory.DraggingSlot.Slot.CanRemoveItem())
            {
                Instantiate<GameObject>(this.inventory.DraggingSlot.CachedSlot.Item.Definition.Prefab, hit.point, Quaternion.identity);
                this.inventory.DraggingSlot.Slot.RemoveItem();
            }

            if (hit.collider.CompareTag("Enemy") && this.inventory.DraggingSlot.Slot.CanRemoveItem())
            {
                Instantiate<GameObject>(this.inventory.DraggingSlot.CachedSlot.Item.Definition.Prefab, hit.point, Quaternion.identity);
                
                this.inventory.DraggingSlot.Slot.RemoveItem();
            }
        }
    }

}
