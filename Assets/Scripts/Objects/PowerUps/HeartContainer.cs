using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PowerUp
{

    public FloatValue heartContainers;
    public FloatValue playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            &&collision.isTrigger)
        {
            heartContainers.runtimeValue++;
            playerHealth.runtimeValue=heartContainers.runtimeValue*2;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
  
}
