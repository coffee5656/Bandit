using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Look : MonoBehaviour
{
    public Transform player;
    public bool IsFlipped = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if(transform.position.x>player.position.x && IsFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            IsFlipped = false;
        }
        
        else if(transform.position.x<player.position.x && !IsFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            IsFlipped = true;
        }
      
        
    }



}
