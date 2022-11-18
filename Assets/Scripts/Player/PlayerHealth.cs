using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{

    [SerializeField] private Signals healthSignal;

    public override void Damage(float amountDamage)
    {
        base.Damage(amountDamage);
        maxHealth.runtimeValue = currentHealth;
        healthSignal.Raise();
    }

}
