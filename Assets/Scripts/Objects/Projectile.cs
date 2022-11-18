using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Vector2 targetDirection;
    public Rigidbody2D projectileRb;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void LaunchProjectile(Vector2 initialTarget)
    {
        projectileRb.velocity = initialTarget * speed;
    }


}
