using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Projectile GenericAbility", fileName ="Projectile Ability")]
public class ProjectileAbility : GenericAbility
{
    [SerializeField] private GameObject projectile;


    public override void Ability(Vector2 playerPosition, Vector2 playerFacingDirection = default, Animator playerAnimator = null, Rigidbody2D playerRb = null)
    {
        base.Ability(playerPosition, playerFacingDirection, playerAnimator, playerRb);

        float facingRotation = Mathf.Atan2(playerFacingDirection.y, playerFacingDirection.x)*Mathf.Rad2Deg;
        GameObject projectileInstance = Instantiate(projectile, playerPosition, Quaternion.Euler(0f, 0f, facingRotation));
        GenericProjectile temp = projectileInstance.GetComponent<GenericProjectile>();
        if (temp)
        {
            temp.Setup(playerFacingDirection);
        }
    }
}
