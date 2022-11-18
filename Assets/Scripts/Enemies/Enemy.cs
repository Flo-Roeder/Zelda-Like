using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Stats")]
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseDamage;
    public float moveSpeed;
    public Vector2 homePosition;

    [Header("On Death")]
    public GameObject deathEffect;
    private float deathDelay=1f;
    public LootTable thisLoot;

    [Header("DeathSignal")]
    public Signals roomSignal;

    private void Awake()
    {
        health = maxHealth.initialValue;
        homePosition=transform.position;
    }


    private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }


    private void DeathEffect()
    {
        if (deathEffect!=null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathDelay);
        }
    }

    private void DropLoot()
    {
        if (thisLoot!=null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if (current!=null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void KnockBack(Rigidbody2D myRb, float knockbackTime)
    {
        StartCoroutine(KnockCo(myRb, knockbackTime));
    }


    private IEnumerator KnockCo(Rigidbody2D myRb, float knockbackTime)
    {
        if (myRb != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            myRb.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }


}
