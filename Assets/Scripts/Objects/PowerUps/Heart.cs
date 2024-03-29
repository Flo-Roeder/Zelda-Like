using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{

    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToHeal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            &&!collision.isTrigger)
        {
            playerHealth.runtimeValue += amountToHeal;
            if (playerHealth.initialValue>heartContainers.runtimeValue*2)
            {
                playerHealth.initialValue = heartContainers.runtimeValue * 2;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
