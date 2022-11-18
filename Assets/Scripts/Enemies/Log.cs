using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Rigidbody2D logRb;
    [Header("Target Vars")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;

    [Header ("Animation")]
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
       

        currentState = EnemyState.idle;
        logRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        //anim.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        CheckDistance();
    }
    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && (currentState==EnemyState.idle || currentState==EnemyState.walk) 
            && currentState!=EnemyState.stagger )
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
            logRb.MovePosition(temp);
            ChangeAnim(temp - transform.position);
            ChangeState(EnemyState.walk);
            anim.SetBool("wakeUp", true);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }

    }

    public void SetAnimFloat(Vector2 vector)
    {
        anim.SetFloat("moveX", vector.x);
        anim.SetFloat("moveY", vector.y);

    }

    public void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x)>=Mathf.Abs(direction.y))
        {
            if (direction.x>0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x<0)
            {
                SetAnimFloat(Vector2.left);

            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }

        }
    }


    public void ChangeState(EnemyState newState)
    {
        if (currentState!=newState)
        {
            currentState = newState;
        }
    }

}
