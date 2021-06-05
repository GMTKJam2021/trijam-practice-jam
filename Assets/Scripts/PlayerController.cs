using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Collider2D col;

    [SerializeField]
    private float moveSpeed = 3;

    private Vector2 moveInput;

    void Awake()
    {
        Debug.Assert(rb != null);
        Debug.Assert(col != null);

        moveInput = Vector2.zero;
    }

    void Start()
    {

    }


    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        rb.AddForce(moveInput.normalized * moveSpeed, ForceMode2D.Force);
    }
}
