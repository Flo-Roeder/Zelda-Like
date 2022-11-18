using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{

    public bool playerInRange;
    public Signals contextChange;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger)
        {
            playerInRange = true;
            contextChange.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger)
        {
            playerInRange = false;
            contextChange.Raise();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
