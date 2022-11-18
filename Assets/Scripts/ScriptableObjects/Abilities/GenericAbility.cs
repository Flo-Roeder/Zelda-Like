using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/GenericAbility", fileName ="New Generic Ability")]

public class GenericAbility : ScriptableObject
{
    public float magicCost;
    public float duration;

    public Inventory playerInventory;
    public Signals usePlayerMagic;


    public virtual void Ability(Vector2 playerPosition, Vector2 playerFacingDirection=new Vector2(), Animator playerAnimator=null, Rigidbody2D playerRb=null)
    {
        if (playerInventory.currentMagic >= magicCost)
        {
            playerInventory.currentMagic -= magicCost;
            usePlayerMagic.Raise();
        }
        else
        {
            return;
        }

    }


}
