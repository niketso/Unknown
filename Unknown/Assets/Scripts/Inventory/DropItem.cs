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
           
            var item = this.inventory.DraggingSlot.CachedSlot.Item;

            if (item.Definition.Prefab.tag == "FireExt" && hit.collider.CompareTag("Fire") && this.inventory.DraggingSlot.Slot.CanRemoveItem())
            {
                //Instantiate<GameObject>(item.Definition.Prefab, hit.point, Quaternion.identity);
                StartCoroutine(hit.transform.GetComponent<Fire>().playSound());
                this.inventory.DraggingSlot.Slot.RemoveItem();

            }

            if (item.Definition.Prefab.tag == "Axe" && hit.collider.CompareTag("Enemy") && this.inventory.DraggingSlot.Slot.CanRemoveItem())
            {
                Instantiate<GameObject>(item.Definition.Prefab, hit.point, Quaternion.identity);
                this.inventory.DraggingSlot.Slot.RemoveItem();

            }

            if (item.Definition.Prefab.tag == "Batteries" && hit.collider.CompareTag("Radio") && this.inventory.DraggingSlot.Slot.CanRemoveItem())
            {
                Instantiate<GameObject>(item.Definition.Prefab, hit.point, Quaternion.identity);
                this.inventory.DraggingSlot.Slot.RemoveItem();
            }

            BasePuzzleBehaviour beh = hit.collider.gameObject.GetComponent<BasePuzzleBehaviour>();
            var cachedSlot = this.inventory.DraggingSlot.CachedSlot;
            if (beh != null)
                beh.OnDrop(cachedSlot);
        }
    }

}
