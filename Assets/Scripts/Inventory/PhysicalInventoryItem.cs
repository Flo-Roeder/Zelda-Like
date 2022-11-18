using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem inventoryItem;


    private void AddItemToInventory()
    {
        if (playerInventory
            && inventoryItem)
        {
            if (playerInventory.myInventory.Contains(inventoryItem))
            {
                inventoryItem.numberHeld++;
            }
            else
            {
                playerInventory.myInventory.Add(inventoryItem);
                inventoryItem.numberHeld++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

}
