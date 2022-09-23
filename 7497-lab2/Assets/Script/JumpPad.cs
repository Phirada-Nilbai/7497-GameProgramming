using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 10f;
    [SerializeField] private float additionSleepJumpTime = 0.3f;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;

    public float GetAdditionSleepJumpTime() => additionSleepJumpTime;

    public void TriggerJumpPad()
    {
        animator.SetTrigger(Bounce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
        }
    }
}
