using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public float attackSpeed;
    private float timer;
    private GameObject player;
    private int numberBullet;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        numberBullet = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 10)
        {
  timer += Time.deltaTime;
        if (timer > attackSpeed)
        {
            timer = 0;
            shoot();
        }
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        numberBullet++;
    }
    public void BulletGone()
    {
        numberBullet--;
    }
}
