using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUp
{

    public Inventory playerInventory;
    public float magicValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInventory.currentMagic += magicValue;
            if (playerInventory.currentMagic>playerInventory.maxMagic)
            {
                playerInventory.currentMagic = playerInventory.maxMagic;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }

}
