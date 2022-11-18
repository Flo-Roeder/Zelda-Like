using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{

    public FloatValue maxHealth;
    public float currentHealth; 

    void Start()
    {
        currentHealth = maxHealth.runtimeValue;
    }

    public virtual void Heal(float amountHeal)
    {
        currentHealth += amountHeal;
        if (currentHealth>maxHealth.runtimeValue)
        {
            currentHealth = maxHealth.runtimeValue;
        }
    }

    public virtual void FullHeal()
    {
        currentHealth = maxHealth.runtimeValue;
    }

    public virtual void Damage(float amountDamage)
    {
        currentHealth -= amountDamage;
        if (currentHealth<=0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
    }

    public virtual void InstantDeath()
    {
        currentHealth = 0;
        gameObject.SetActive(false);
    }
}
