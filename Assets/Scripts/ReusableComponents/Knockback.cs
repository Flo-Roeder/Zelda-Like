using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{

    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    [SerializeField] private string otherTag;
    //public float damage;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("breakable") 
            && this.CompareTag("Player"))
        {
            collision.GetComponent<Pot>().Smash();
        }
        */
        if (collision.CompareTag(otherTag)
            && collision.isTrigger)
        {
            if (this.CompareTag("enemy") 
                && collision.CompareTag("enemy"))
            {
                //do nothing when both are enemys
            }
            else
            {
                Rigidbody2D hitRb = collision.GetComponentInParent<Rigidbody2D>();
                if (hitRb!=null)
                {
                    Vector3 difference = hitRb.transform.position - transform.position;
                    difference = difference.normalized * knockbackForce;
                    hitRb.DOMove(hitRb.transform.position + difference, knockbackTime);
                    
                    if (collision.CompareTag("enemy")
                        && collision.isTrigger)
                    {
                       hitRb.GetComponent<Enemy>().currentState = EnemyState.stagger;
                       collision.GetComponent<Enemy>().KnockBack(hitRb, knockbackTime);
                    }
                    if (collision.CompareTag("Player"))
                    {
                        if (collision.GetComponentInParent<PlayerMove>().currentState!=PlayerState.stagger)
                        {
                        hitRb.GetComponentInParent<PlayerMove>().currentState = PlayerState.stagger;
                        collision.GetComponentInParent<PlayerMove>().Knockback(knockbackTime);
                        }
                    }
                }
            }
        }
    }


}
