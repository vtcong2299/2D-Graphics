using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb2D;
    //public PlayerDameReceiver playerDameReceiver;
    private float pressHorizontal;
    public int speed = 5;
    public float powerJump = 17;
    [SerializeField]
    private bool facingRight = true;
    [SerializeField]
    private bool maybeJump;
    [SerializeField]
    private bool doubleJump;
    [SerializeField]
    private Transform posJump;
    [SerializeField]
    private LayerMask layerSan;
    private void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        //playerDameReceiver = new PlayerDameReceiver();
    }  
    private void Update()
    {        
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");
        CheckRun();
        UpdateJumb();
        UpdateMove();
        Attack1();
        //if(playerDameReceiver.IsDead())
        //{
        //    speed = 0;
        //    powerJump = 0;
        //}
    }
    public void UpdateMove()
    {
        rb2D.velocity =  new Vector2 (pressHorizontal*speed, rb2D.velocity.y);
    }
    public void UpdateJumb()
    {
        maybeJump = Physics2D.OverlapCircle(posJump.position, 0.1f, layerSan);        
        if (maybeJump && !Input.GetKey(KeyCode.UpArrow))
        {
            doubleJump = false;            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (maybeJump||doubleJump)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, powerJump);
                PlayerAnimatorManager.instance.SetJump();
                doubleJump = !doubleJump;
            }
        }        
    }
    public void Attack1()
    {
        if (!PlayerAnimatorManager.instance.inGround)
        {
            if (Input.GetKey(KeyCode.J))
            {
                PlayerAnimatorManager.instance.SetAttackJump();
            }
            else
            {
                PlayerAnimatorManager.instance.SetNotAttackJump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            int randomIndex = Random.Range(0, 2);            
            if (randomIndex == 0)
            {
                PlayerAnimatorManager.instance.SetAttack1();
            }
            else
            {
                PlayerAnimatorManager.instance.SetAttack2(); 
            }              
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerAnimatorManager.instance.SetInGround(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerAnimatorManager.instance.SetNotInGround(collision);
    }
    public void CheckRun()
    {
        if(this.pressHorizontal != 0)
        {
            PlayerAnimatorManager.instance.SetIsRun();
        }
        else
        {
            PlayerAnimatorManager.instance.SetNotRun();
        }
        if (this.pressHorizontal< 0 && facingRight)
        {
            Flip();
        }
        if (this.pressHorizontal> 0 && !facingRight)
        {
            Flip();
        }
    }
    public void Flip()
    {
        Vector3 curScale = transform.localScale;
        curScale.x = -1*curScale.x;
        transform.localScale = curScale;
        facingRight = !facingRight;
    }
    
}
