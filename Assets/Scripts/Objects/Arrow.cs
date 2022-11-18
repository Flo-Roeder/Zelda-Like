using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float speed;
    public Rigidbody2D arrowRb;
    public float lifeTime;
    private float lifeTimeCounter;
    public float magicCost;

    private void Start()
    {
        lifeTimeCounter = lifeTime;
    }

    private void Update()
    {
        lifeTimeCounter -= Time.deltaTime;
        if (lifeTimeCounter<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        arrowRb.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
        Destroy(this.gameObject);

        }
    }

}
