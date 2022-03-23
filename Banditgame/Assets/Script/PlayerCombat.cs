using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage = 40;
    public float attackRate = 1f;
    float nextAttackTime = 0f;

    public bool isClick;//是否点击
    public float tempTime = 0;//计时器
    public Button Btn;//按钮
    void Start()
    {
        Btn.onClick.AddListener(OnClick);//注册按钮事件
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isClick)//如果被点击
        {
            tempTime += Time.deltaTime;
            if (tempTime > 1)
            {
                tempTime = 0;
                Btn.enabled = true;
                isClick = false;
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Attack();
                nextAttackTime =Time.time+ 1f / attackRate;
            }
        }
     }

    private void OnClick()
    {
        isClick = true;
        Btn.enabled = false;
    }

    public void Attack()
    {
        //播放攻擊動畫
        animator.SetTrigger("Attack");
        //偵測攻擊範圍裡的敵人
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //攻擊
        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }

}
