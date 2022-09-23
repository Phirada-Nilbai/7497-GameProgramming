using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerAnimatorController animatorController;
    [SerializeField] private Collider2D playerCollider;

    [Header("Player Value")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 0.01f;

    //
    private float _moveInput;
    //
    private bool _isGrounded;
    private void Update()
    {
        CheckGround();
        animatorController.SetAnimatorParameter(rb.velocity,_isGrounded);
    }
    private void FixedUpdate()
    {
        Move();
    }



    #region Actions
    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * moveSpeed,rb.velocity.y);
    }

    private void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(force * transform.up, ForceMode2D.Impulse);

    }

    private void TryJumping()
    {
        if(!_isGrounded) return;

        Jump(jumpForce);
    }
    private void FlipPlayerSprites()
    {
        if(_moveInput < 0)
        {
            player.localScale = new Vector3(-1,1,1);
        }
        else if (_moveInput > 0)
        {
            player.localScale = Vector3.one;
        }
    }

    private void CheckGround()
    {
        var playerColliderBounds = playerCollider.bounds;
        
        var raycastHit = Physics2D.BoxCast(
            playerColliderBounds.center,
            playerColliderBounds.size,
            0f,
            Vector2.down,
            groundCheckDistance,
            groundLayers);

        _isGrounded = raycastHit.collider != null;

            
    }
    #endregion




    #region Input
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();

        FlipPlayerSprites();
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;


        TryJumping();
        
    }
    #endregion
}
