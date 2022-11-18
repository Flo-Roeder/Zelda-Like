using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundedDistance;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) >
            attackRadius
            && (currentState == EnemyState.idle || currentState == EnemyState.walk)
            && currentState != EnemyState.stagger)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            logRb.MovePosition(temp);
            ChangeAnim(temp - transform.position);
            anim.SetBool("wakeUp", true);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            //patrol
            if (Vector3.Distance(transform.position,path[currentPoint].position)>roundedDistance)
            {
            Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
            logRb.MovePosition(temp);
            ChangeAnim(temp - transform.position);
            }
            else
            {
                ChangeGoal();
            }

        }

    }

    private void ChangeGoal()
    {
        if (currentPoint==path.Length-1)
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
            currentGoal = path[currentPoint];
    }


}
