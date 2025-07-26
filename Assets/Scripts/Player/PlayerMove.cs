using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 minLimit;
    public Vector2 maxLimit;

    private Rigidbody2D _rigidBody;
    private Animator animator;

    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;

        if (movement != Vector2.zero)
        {
            lastDirection = movement;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);
    }

    void FixedUpdate()
    {
        Vector2 newPosition = _rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minLimit.x, maxLimit.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minLimit.y, maxLimit.y);

        _rigidBody.MovePosition(newPosition);
    }
}


