using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public int maxhealth=100;
    int currenthealth;
    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 10f;
    public HealthBar healthbar;
    bool gameHasEnd = false;
    public Transform trans;
    public Vector2 pos;
   

   



    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        

    }

    void Update()
    {
        pos = trans.position;
        if (pos.y < -10f)
        {
            WinGame();
        }
    }


    public void TakeDamage(int damage)
        
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);

        //播放受傷動畫
        animator.SetTrigger("hurt");
                
        if (currenthealth <= 0)
        {
            Die();
        }

        void Die()
        {
            
            //播放死亡動畫
            animator.SetBool("IsDead", true);
            
            rb.velocity= new Vector2(speed, speed);

            //使敵人無效
            GetComponent<Collider2D>().enabled = false;
            


            
        }
         
    }
    public void WinGame()
    {
        if (gameHasEnd == false)
        {
            gameHasEnd = true;
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("thanks");
    }
}   