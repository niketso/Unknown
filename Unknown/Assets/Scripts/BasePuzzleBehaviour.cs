using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasePuzzleBehaviour : MonoBehaviour
{
    public Inventory inventory;

    private void OnEnable()
    {
        EventManager.InventoryChanged += EventManager_InventoryChanged;
    }

    private void OnDisable()
    {
        EventManager.InventoryChanged -= EventManager_InventoryChanged;
    }

    // Use this for initialization
    void Start()
    {

    }
    protected virtual void CheckInventory()
    {

    }
    public void OnDrop(Slot slot)
    {
        OnDropInternal(slot.Item.Definition.Prefab);
    }
    protected virtual void OnDropInternal(GameObject slot) {

    }
    protected bool InventoryContainsItem(string prefabName)
    {
        return inventory.ContainsItemWithDefinition(prefabName);
    }
    protected void UseItem(string prefabName)
    {
        inventory.UseItemWithName(prefabName);
    }
    private void EventManager_InventoryChanged()
    {
        //check inventory for Items I need
        CheckInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
