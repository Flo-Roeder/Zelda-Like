using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Dash GenericAbility", fileName = "Dash Ability")]

public class DashAbility : GenericAbility
{
    public float dashForce;

    public override void Ability(Vector2 playerPosition, Vector2 playerFacingDirection = default, Animator playerAnimator = null, Rigidbody2D playerRb = null)
    {
        base.Ability(playerPosition, playerFacingDirection, playerAnimator, playerRb);

        if (playerRb)
        {
            Vector3 dashVector = playerRb.transform.position + (Vector3)playerFacingDirection.normalized * dashForce;
            playerRb.DOMove(dashVector, duration);
        }
    }


}
