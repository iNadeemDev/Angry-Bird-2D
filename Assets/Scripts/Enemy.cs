using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D Target)
    {
        if (Target.collider.GetComponent<Bird>())
        {
            ScoreBoard.GetInstance().AddScore(100);
            ScoreBoard.GetInstance().AddKills(1);
            AudioManager.instance.PlayMySound("start");
            Destroy(gameObject);
            
        }
        else if(Target.contacts[0].normal.y < 0.5)
        {
            ScoreBoard.GetInstance().AddScore(100);
            ScoreBoard.GetInstance().AddKills(1);
            AudioManager.instance.PlayMySound("start");
            Destroy(gameObject);
        
        }
    }
}
