using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public Enemy[] roomEnemies;
    public Pot[] roomPots;

    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger)
        {
            foreach (var item in roomEnemies)
            {
                ChangeActiveStatus(item, true);
            }
            foreach (var item in roomPots)
            {
                ChangeActiveStatus(item, true);
            }

            virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && !collision.isTrigger)
        {
            foreach (var item in roomEnemies)
            {
                ChangeActiveStatus(item, false);
            }
            foreach (var item in roomPots)
            {
                ChangeActiveStatus(item, false);
            }

            virtualCamera.SetActive(false);
        }

    }

    public void OnDisable()
    {
        virtualCamera.SetActive(false);
    }

    public void ChangeActiveStatus(Component component, bool activateStatus)
    {
        if (component)
        {
        component.gameObject.SetActive(activateStatus);

        }
    }
}
