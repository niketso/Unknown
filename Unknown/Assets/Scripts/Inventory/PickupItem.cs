using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    [SerializeField]
    protected ItemDefinition definition;
    [SerializeField]
    protected AudioClip pickUpSound;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerPickup player = collider.GetComponent<PlayerPickup>();
            if (player != null)
            {
                player.Inventory.AddNewItem(new Item(this.definition, 1));
                player.gameObject.GetComponent<AudioSource>().PlayOneShot(pickUpSound);
                Destroy(gameObject);
            }
        }
    }

}
