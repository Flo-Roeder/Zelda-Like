using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Log
{

    public GameObject projectile;
    public float fireRate;
    private float fireRateTimer;
    private bool canFire;

    private void Awake()
    {
        fireRateTimer = fireRate;
        homePosition=transform.position;
    }


    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
    && Vector3.Distance(target.position, transform.position) > attackRadius
    && (currentState == EnemyState.idle || currentState == EnemyState.walk)
    && currentState != EnemyState.stagger)
        {
            FireRateTimer();
            anim.SetBool("wakeUp", true);
            ChangeState(EnemyState.walk);

            if (canFire)
            {
            Vector3 tempTargetVector =  (target.transform.position - transform.position).normalized;
            GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            currentProjectile.GetComponent<Projectile>().LaunchProjectile(tempTargetVector);
            canFire = false;

            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            fireRateTimer = fireRate;
        }

    }

    private void FireRateTimer()
    {
        fireRateTimer -= Time.deltaTime;
        if (fireRateTimer <= 0)
        {
            fireRateTimer = fireRate;
            canFire = true;
        }

    }

}
