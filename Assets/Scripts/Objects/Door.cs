using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}



public class Door : Interactible
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool isOpen;

    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;




    private void Update()
    {
        if (Input.GetButtonDown("attack"))
        {
            if (playerInRange&&thisDoorType==DoorType.key)
            {
                if (playerInventory.numberOfKeys>0)
                {
                    playerInventory.numberOfKeys--;
                    DoorOpen();
                }
            }
        }
    }

    public void DoorOpen()
    {
        doorSprite.enabled = false;
        isOpen = true;
        physicsCollider.enabled = false;
    }

    public void DoorClose()
    {
        doorSprite.enabled = true;
        isOpen = false;
        physicsCollider.enabled = true;

    }

}
