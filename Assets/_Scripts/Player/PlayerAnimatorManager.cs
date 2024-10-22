using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    public Animator animator;
    public static PlayerAnimatorManager instance;
    public bool inGround;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void SetDead()
    {
        animator.SetTrigger("isDead");
    }
    public void SetAttack1()
    {
        animator.SetTrigger("Attack1");
    }
    public void SetAttack2()
    {
        animator.SetTrigger("Attack2");
    }
    public void SetAttackJump()
    {
        animator.SetTrigger("AttackJump");
    }
    public void SetNotAttackJump()
    {
        animator.SetTrigger("NotAttackJump");
    }
    public void SetIsRun()
    {
        animator.SetBool("isRun", true);
    }
    public void SetNotRun()
    {
        animator.SetBool("isRun", false);
    }
    public void SetJump()
    {
        animator.SetTrigger("Jump");
    }
    public void SetInGround(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;
            animator.SetBool("inGround", true);
        }
    }
    public void SetNotInGround(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = false;   
            animator.SetBool("inGround", false);
        }
    }
}
