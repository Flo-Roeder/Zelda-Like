using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string otherTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(otherTag)
            && collision.isTrigger)
        {
            GenericHealth temp = collision.GetComponent<GenericHealth>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }

}
