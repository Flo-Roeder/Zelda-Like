using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : Room
{
    public Door[] roomDoors;

    private void Update()
    {
        
    }

    public void CheckEnemies()
    {
        
        foreach (var item in roomEnemies)
        {
            if (item.gameObject.activeInHierarchy)
            {
                return;
            }
            OpenDoors();

        }
    }

    public void CloseDoors()
    {
        foreach (var item in roomDoors)
        {
            item.DoorClose();
        }
    }

    public void OpenDoors()
    {
        foreach (var item in roomDoors)
        {
            item.DoorOpen();
        }
    }

}
