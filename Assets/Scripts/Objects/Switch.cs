using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer switchSprite;
    public Door thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        switchSprite = GetComponent<SpriteRenderer>();
        active = storedValue.runtimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        active = true;
        storedValue.runtimeValue = active;
        thisDoor.DoorOpen();
        switchSprite.sprite = activeSprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }

 
}
