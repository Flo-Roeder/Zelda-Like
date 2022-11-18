using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public override void OnTriggerEnter2D(Collider2D collision)
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
            CloseDoors();
            virtualCamera.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
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
                virtualCamera.SetActive(false);
            }
        }

    }
}
