using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    bool gameHasEnded = false;
    public int maxhealth = 100;
    int currenthealth;
    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 10f;
    public AudioSource audiosource;
    public AudioClip audioclip;
    public GameObject gameoverUI;



    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        
    }

    public void TakeDamage(int damage)

    {
        currenthealth -= damage;
        

        //播放受傷動畫
        animator.SetTrigger("hurt");

        if (currenthealth <= 0)
        {
            PlayerDie();
            

        }

         

    }
    void PlayerDie()
    {

        //播放死亡動畫
        animator.SetBool("IsDead", true);
        gameoverUI.SetActive(true);
        audiosource.PlayOneShot(audioclip);

        rb.velocity= new Vector2(speed, speed);

        //使玩家無效
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;


    }
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }
    
    void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
