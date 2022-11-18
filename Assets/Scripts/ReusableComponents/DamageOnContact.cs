using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField] private string otherTag;
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(otherTag))
        {
            GenericHealth tempHealth = collision.gameObject.GetComponent<GenericHealth>();
            if (tempHealth)
            {
                tempHealth.Damage(damage);
            }
            Destroy(this.gameObject);
        }
    }

}
