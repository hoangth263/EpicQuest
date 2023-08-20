using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum EnemyState
    {
        idle,
        walk,
        attack,
        stagger 
    }
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public PlayerHealth player;
    public float attachSpeed;
    public float canAttack;
    // Start is called before the first frame update

   
    // Update is called once per frame

}
