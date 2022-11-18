using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactible
{
    [Header("Content")]
    public Item content;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue saveOpen;

    [Header("Signals/Dialog")]
    public Signals raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = saveOpen.runtimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Weapon")
            && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestIsOpen();
            }
        }

    }


    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = content.itemDescription;
        playerInventory.AddItem(content);
        playerInventory.currentItem = content;
        raiseItem.Raise();
        isOpen = true;
        saveOpen.runtimeValue = isOpen;
        contextChange.Raise();
        anim.SetBool("opened", true);

    }

    public void ChestIsOpen()
    {
        //playerInventory.currentItem = null;
        raiseItem.Raise();
        dialogBox.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger
            &&!isOpen)
        {
            playerInRange = true;
            contextChange.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger
            &&!isOpen)
        {
            playerInRange = false;
            contextChange.Raise();
        }
    }


}
