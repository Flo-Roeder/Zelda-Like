using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Sign
{

    private Vector3 directionVector;
    private Transform npcTransform;
    public float speed;
    private Rigidbody2D npcRb;
    private Animator anim;
    public Collider2D bound;

    private bool isMoving = true;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeCounter;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        moveTimeCounter = Random.Range(minMoveTime, maxMoveTime);
        waitTimeCounter = Random.Range(minWaitTime, maxWaitTime);
        npcTransform = GetComponent<Transform>();
        npcRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeMoveDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isMoving)
        {
            moveTimeCounter -= Time.deltaTime;
            if (moveTimeCounter<=0)
            {
                moveTimeCounter = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
            }

            if (!playerInRange)
            {
            MoveNPC();
            }
        }
        else
        {
            waitTimeCounter -= Time.deltaTime;
            if (waitTimeCounter<=0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeCounter = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }

    private void MoveNPC()
    {
        Vector3 temp = npcTransform.position + directionVector * speed * Time.deltaTime;
        if (bound.bounds.Contains(temp))
        {
        npcRb.MovePosition(temp);        
        }
        else
        {
            ChangeMoveDirection();
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeMoveDirection();
        if (temp == directionVector)
        {
            ChangeMoveDirection();
        }

    }

    private void ChangeMoveDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0: directionVector = Vector3.right;
                break;
            case 1: directionVector = Vector3.up;
                break;
            case 2: directionVector = Vector3.left;
                break;
            case 3: directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnim();
    }

    private void UpdateAnim()
    {
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChooseDifferentDirection();
    }

}
