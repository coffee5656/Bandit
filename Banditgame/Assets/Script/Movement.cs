using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGround;
    public float JumpSpeed;
    public Animator animator;
    public float MoveSpeed = 5.0f;
    public Joystick joystick;

    //在角色下新增一個空物體
    //設定一個跳躍監測點
    public Transform CheckPoint;
    //設定一個跳躍監測半徑
    public float CheckRadius;
    //設定一個跳躍監測層---角色與地面的檢測
    public LayerMask WhatIsGround;

    
 
     
    
     void Update()
    {
        //檢查用
        isGround = Physics2D.OverlapCircle(CheckPoint.position, CheckRadius, WhatIsGround);
        float verticalMove = joystick.Vertical;

        if (verticalMove>=0.5f && isGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
            animator.SetBool("IsJumping", true);

        }
        
        if (joystick.Horizontal >= 0.2f)
        {
            rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1f, 1f);

        }
        //角色水平移動
        //按住A鍵，判斷如果小於0，則向左開始移動
        else if (joystick.Horizontal <= -0.2f)
        {
            rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);

        }
        else
        //角色水平移動
        //鬆開按鍵，判斷如果等於0，則停止移動
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        animator.SetFloat("Speed",Mathf.Abs( rb.velocity.x));

        if (rb.velocity.y < -80f)
        {
            FindObjectOfType<PlayerHealth>().EndGame();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }
    }
}

