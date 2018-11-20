using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void InventoryChangedEvent();
    public static event InventoryChangedEvent InventoryChanged;

    public void DoInventoryChanged()
    {
        if (InventoryChanged != null)
            InventoryChanged.Invoke();
    }
}
