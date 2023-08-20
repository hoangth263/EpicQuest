using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timeDisplay;
    private bool displayBullet;
    private float number;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot= Mathf.Atan2(-direction.x, -direction.y)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,-rot); 
       displayBullet = true;
        number = Time.deltaTime;
        Destroy(gameObject,8);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-1);
           gameObject.SetActive(false);
            return;
        }
    }
}
