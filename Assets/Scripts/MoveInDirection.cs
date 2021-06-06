using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float speed;

    private void Awake()
    {
        Debug.Assert(rb != null);
        Debug.Assert(direction != Vector2.zero);
        Debug.Assert(speed > 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode2D.Force);
    }
}
