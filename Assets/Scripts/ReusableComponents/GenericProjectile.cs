using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GenericProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 moveDirection)
    {
        Rb.velocity = moveDirection.normalized * speed;
    }
}
