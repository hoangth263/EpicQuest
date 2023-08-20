using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerHit : MonoBehaviour
{

    // Start is called before the first frame update
    // Update is called once per frame

    public int damePlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            other.GetComponent<pot>().Smash();
        }
        else
        if (other.CompareTag("enemy"))
        {
            Enemy thisEnemy = other.gameObject.GetComponent<Enemy>();
            thisEnemy.currentState = EnemyState.stagger;
            thisEnemy.health -= damePlayer;
            if (thisEnemy.health <= 0)
            {
                SoundManager.instance.MonsterDying();
                thisEnemy.gameObject.SetActive(false);
            }
            else
            {
                SoundManager.instance.HittingMonster();
            }
        }
    }

}


// Start is called before the first frame update





