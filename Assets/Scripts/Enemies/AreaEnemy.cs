using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Log
{
    [Header("Bounderies")]
    public Collider2D boundary;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && boundary.bounds.Contains(target.transform.position)
            && (currentState == EnemyState.idle || currentState == EnemyState.walk)
            && currentState != EnemyState.stagger)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            logRb.MovePosition(temp);
            ChangeAnim(temp - transform.position);
            ChangeState(EnemyState.walk);
            anim.SetBool("wakeUp", true);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius
            || !boundary.bounds.Contains(target.transform.position))
        {
            anim.SetBool("wakeUp", false);
        }
    }


}
