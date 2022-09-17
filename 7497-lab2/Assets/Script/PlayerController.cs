using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    private float _moveInput;
    private float moveSpeed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * moveSpeed,rb.velocity.y);
    }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            /*Debug.Log("Jump")*/
            rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
        }
    }
}
